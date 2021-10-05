using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGuardController : AIController
{
    // Update is called once per frame
    void Update()
    {
        // Only Turn towards player and shoot
        if (currentState == AIStates.TurnAndShootStatic)
        {
            DoTurnAndShoot();
        }
        // Can See Test
        if (currentState == AIStates.CanSeeLog)
        {
            CanSee();
        }
        // End of Can See Test

        // Stay in Patrol
        if (currentState == AIStates.PatrolStatic)
        {
            DoPatrol();
        }
        // End of Stay in Patrol

        // Stay in Flee
        if (currentState == AIStates.FleeStatic)
        {
            if (avoidanceStage != 0)
            {
                DoAvoidance();
            }
            else
            {
                DoFlee();
            }
            if (TimeInCurrentStateIsGreaterThan(3))
            {
                avoidanceStage = 0;
                ChangeState(AIStates.IdleFlee);
            }
        }

        if (currentState == AIStates.IdleFlee)
        {
            //do the action for idle
            DoIdle();

            //Check for transitions
            if ((IsTankClose(GameManager.instance.players[0].myObjectData)) || (CanSee()))
            {
                //ChangeState
                ChangeState(AIStates.FleeStatic);
            }
        }
        // End of Stay in Flee

        // Stay in Chase
        if (currentState == AIStates.ChaseStatic)
        {
            if (avoidanceStage != 0)
            {
                DoAvoidance();
            }
            else
            {
                DoChase();
            }
            if (TimeInCurrentStateIsGreaterThan(3))
            {
                avoidanceStage = 0;
                ChangeState(AIStates.IdleChase);
            }
        }

        if (currentState == AIStates.IdleChase)
        {
            //do the action for idle
            DoIdle();

            //Check for transitions
            if ((IsTankClose(GameManager.instance.players[0].myObjectData)) || (CanSee()))
            {
                //ChangeState
                ChangeState(AIStates.ChaseStatic);
            }
        }
        // End of Stay in Flee

        // Start of Normal Enemy
        if (currentState == AIStates.Patrol)
        {
            DoPatrol();
            // if player is within hearing distance or FOV, then change state
            // health determines which state
            if (((IsTankClose(GameManager.instance.players[0].myObjectData)) || (CanSee())) && (myObjectData.MaxHealth > (myObjectData.CurrentMaxHealth / 2)))
            {
                ChangeState(AIStates.Chase);
            }
            else if (((IsTankClose(GameManager.instance.players[0].myObjectData)) || (CanSee())) && (myObjectData.MaxHealth <= (myObjectData.CurrentMaxHealth / 2)))
            {
                ChangeState(AIStates.Flee);
            }
        }

        if (currentState == AIStates.Chase)
        {
            if (avoidanceStage != 0)
            {
                DoAvoidance();
            }
            else
            {
                DoChase();
                // Shoot if can see and hear
                if ((IsTankClose(GameManager.instance.players[0].myObjectData)) && (CanSee()))
                {
                    ChangeState(AIStates.TurnAndShoot);
                }
            }
            if (TimeInCurrentStateIsGreaterThan(3))
            {
                avoidanceStage = 0;
                ChangeState(AIStates.Patrol);
            }
        }

        // stop and shoot, change back to chase if cant see or cant hear
        if (currentState == AIStates.TurnAndShoot)
        {
            DoTurnAndShoot();
            if ((!IsTankClose(GameManager.instance.players[0].myObjectData)) || (!CanSee()))
            {
                ChangeState(AIStates.Chase);
            }
        }

        if (currentState == AIStates.Flee)
        {
            if (avoidanceStage != 0)
            {
                DoAvoidance();
            }
            else
            {
                DoFlee();
            }
            if (TimeInCurrentStateIsGreaterThan(3))
            {
                avoidanceStage = 0;
                ChangeState(AIStates.Patrol);
            }
        }
        // End of Normal Enemy
    }
}
