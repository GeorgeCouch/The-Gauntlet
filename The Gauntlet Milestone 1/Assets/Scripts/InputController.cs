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
        // Quit game if ESC is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            myObjectData.mover.Spin();
        }
        
        // Controls for WASD Space
        if (controls == ControlType.WASD)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myObjectData.shooter.Shoot();
            }

            if (Input.GetKey(KeyCode.W))
            {
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
        } else
        {
            // Controlls for IJKL P
            if (controls == ControlType.IJKL)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myObjectData.shooter.Shoot();
                }

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
