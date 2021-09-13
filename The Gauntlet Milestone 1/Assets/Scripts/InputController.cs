using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    public enum ControlType { WASD, IJKL };
    public ControlType controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myObjectData.shooter.Shoot();
        }

        if (controls == ControlType.WASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // TODO: Move forward!
                myObjectData.mover.MoveForward();
            }

            if (Input.GetKey(KeyCode.S))
            {
                myObjectData.mover.MoveBackward();
            }

            if (Input.GetKey(KeyCode.A))
            {
                myObjectData.mover.RotateRight();
            }

            if (Input.GetKey(KeyCode.D))
            {
                myObjectData.mover.RotateLeft();
            }

            // TODO: All other Directions
        } else
        {
            if (controls == ControlType.IJKL)
            {
                if (Input.GetKey(KeyCode.I))
                {
                    // TODO: Move forward!
                    myObjectData.mover.MoveForward();
                }

                if (Input.GetKey(KeyCode.K))
                {
                    myObjectData.mover.MoveBackward();
                }

                if (Input.GetKey(KeyCode.J))
                {
                    myObjectData.mover.RotateRight();
                }

                if (Input.GetKey(KeyCode.L))
                {
                    myObjectData.mover.RotateLeft();
                }
            }
        }
    }
}
