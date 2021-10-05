using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //My FSM states
    public enum AIStates { Idle, Chase, TurnAndShoot, ChaseAndShoot, Flee, Patrol, PatrolStatic, FleeStatic, IdleFlee, ChaseStatic, IdleChase, CanSeeLog, TurnAndShootStatic };
    public AIStates currentState;
    // Aditional variables for decision making
    // howFarIsClose will work for hearing
    public float howFarIsClose = 1;
    public float timeEnteredCurrentState;
    // Variables for patrolling
    public Transform[] wayPoints;
    private int currentPoint = 0;
    private float dist;
    // Variables for object avoidance
    public int avoidanceStage = 0;
    private float exitTime;
    // Variables for enemy FOV
    public float fieldOfView = 45.0f;
    public float maxViewDistance = 5.0f;

    public bool CanSee ()
    {
        // Find the target's Transform component
        // Find the vector from the agent to the target
        Vector3 agentToTargetVector = GameManager.instance.players[0].myObjectData.transform.position - myObjectData.transform.position;
        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
        float angleToTarget = Vector3.Angle(agentToTargetVector, transform.forward);
        // if that angle is less than our field of view
        if ( angleToTarget < fieldOfView )
        {
            // Raycast
            RaycastHit hitInfo;
            if (Physics.Raycast(myObjectData.transform.position, agentToTargetVector, out hitInfo, maxViewDistance))
            {
                //Debug.Log(hitInfo.collider.gameObject);
                // If the first object we hit is our target
                if (hitInfo.collider.CompareTag("Player"))
                {
                    //Debug.Log("CanSee Player");
                    return true;
                }
            }
        }
        //Debug.Log("Can't See Player");
        return false;
    }

    public void DoPatrol ()
    {
        //Reach waypoint
        // Get distance to next waypoint
        dist = Vector3.Distance(myObjectData.transform.position, wayPoints[currentPoint].position);
        // if within distance, go to next waypoint
        if (dist < 1f)
        {
            if ((currentPoint + 1) > (wayPoints.Length - 1))
            {
                currentPoint = 0;
            }
            else
            {
                currentPoint++;
            }
        }
        else
        {
            // get direction to waypoint and turn towards it
            Vector3 dirFromAtoB = (myObjectData.transform.position - wayPoints[currentPoint].transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, myObjectData.transform.forward);
            TurnTowards(wayPoints[currentPoint]);
            // if facing waypoint, move forward
            if(dotProd < -0.99)
            {
                myObjectData.mover.MoveForward();
            }
        }
    }

    // Shoot using shooter
    public void DoTurnAndShoot()
    {
        TurnTowardsPlayer();
        myObjectData.shooter.Shoot();
    }

    public void ChangeState ( AIStates newState )
    {
        //Actually change the state
        currentState = newState;

        //Save the time that I changed states
        timeEnteredCurrentState = Time.time;
    }

    public void DoIdle ()
    {
        //Do everything i do frame draw while idling
        //Do NOthing
    }

    public void DoChase ()
    {
        //Do everything i need to chase!
        if (CanMove(myObjectData.forwardSpeed))
        {
            //Turn towards player
            TurnTowardsPlayer();
            //Move Forward
            myObjectData.mover.MoveForward();
        }
        else
        {
            avoidanceStage = 1;
        }
    }

    // Avoid obstacles
    public void DoAvoidance()
    {
        if (avoidanceStage == 1)
        {
            // Rotate degrees specified by designers if obstacle found
            if (TimeInCurrentStateIsGreaterThan(1))
            {
                myObjectData.mover.RotateRight();
            }
            if (CanMove(myObjectData.forwardSpeed))
            {
                avoidanceStage = 2;
                exitTime = 1;
            }
        }
        else if (avoidanceStage == 2)
        {
            // Move forward for a second
            if (CanMove(myObjectData.forwardSpeed))
            {
                exitTime -= Time.deltaTime;
                myObjectData.mover.MoveForward();
                if (exitTime <= 0)
                {
                    avoidanceStage = 0;
                }
            }
            else
            {
                avoidanceStage = 1;
            }
        }
    }

    public bool CanMove(float speed)
    {
        // Cast a ray forward in the distance that we sent in
        RaycastHit hit;

        // If our raycast hit something...
        if (Physics.Raycast(myObjectData.transform.position, myObjectData.transform.forward, out hit, speed))
        {
            // ... and if what we hit is not the player...
            if (!hit.collider.CompareTag("Player"))
            {
                // ... then we can't move
                return false;
            }
        }
        // otherwise, we can move, so return true
        return true;
    }

    public void DoFlee ()
    {
        if (CanMove(myObjectData.forwardSpeed))
        {
            //Turn towards player
            TurnAway(GameManager.instance.players[0].myObjectData.transform.position);
            //Move Forward
            myObjectData.mover.MoveForward();
        }
        else
        {
            avoidanceStage = 1;
        }
    }

    public void TurnTowards(Vector3 position)
    {
        //Find the vector that points from this object to the position
        Vector3 vectorToTarget = position - myObjectData.transform.position;

        //find the rotation instructions that will cause me to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Turn a little bit towards that goal. (Just enough that when we run this every frame, we move at myObjectData.data.turnspeed degrees per second )
        myObjectData.transform.rotation = Quaternion.RotateTowards(myObjectData.transform.rotation, targetRotation, myObjectData.turnSpeed * Time.deltaTime);
    }

    public void TurnAway(Vector3 position)
    {
        //Find the vector that points from this object to the position
        Vector3 vectorToTarget = position - myObjectData.transform.position;
        vectorToTarget *= -1;

        //find the rotation instructions that will cause me to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Turn a little bit towards that goal. (Just enough that when we run this every frame, we move at myObjectData.data.turnspeed degrees per second )
        myObjectData.transform.rotation = Quaternion.RotateTowards(myObjectData.transform.rotation, targetRotation, myObjectData.turnSpeed * Time.deltaTime);
    }


    public void TurnTowards(Transform transform)
    {
        TurnTowards(transform.position);
    }

    public void TurnTowardsPlayer()
    {
        TurnTowards(GameManager.instance.players[0].myObjectData.transform);
    }

    public void TurnAwayPlayer()
    {
        TurnTowards(GameManager.instance.players[0].myObjectData.transform);
    }

    public void TurnTowards (GameObject targetObject)
    {
        TurnTowards(targetObject.transform);
    }

    public bool IsTankClose (TankData tankToCheck)
    {
        //Definition of close
        if (Vector3.Distance(myObjectData.transform.position, tankToCheck.transform.position) <= howFarIsClose)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool TimeInCurrentStateIsGreaterThan(float time)
    {
        // If the current time is > time
        if (Time.time > timeEnteredCurrentState + time)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
