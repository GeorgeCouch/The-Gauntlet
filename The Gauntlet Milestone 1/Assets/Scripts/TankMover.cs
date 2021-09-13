using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    private Rigidbody rb;
    private TankData data;
    // Start is called before the first frame update
    void Start()
    {
        // Load the rigidbody
        rb = this.gameObject.GetComponent<Rigidbody>();
        // Load the data
        data = this.gameObject.GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveForward()
    {
        rb.MovePosition(rb.position + (transform.forward * data.forwardSpeed * Time.deltaTime));
    }

    public void MoveBackward()
    {
        rb.MovePosition(rb.position - (transform.forward * data.backwardSpeed * Time.deltaTime));
    }

    public void RotateRight()
    {
        transform.Rotate(0, -data.turnSpeed * Time.deltaTime, 0);
    }

    public void RotateLeft()
    {
        transform.Rotate(0, data.turnSpeed * Time.deltaTime, 0);
    }
}
