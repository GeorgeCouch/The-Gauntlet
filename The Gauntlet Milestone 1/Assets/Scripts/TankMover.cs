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

    // Move Forward and Backward at MPS
    public void MoveForward()
    {
        rb.MovePosition(rb.position + (transform.forward * data.forwardSpeed * Time.deltaTime));
    }

    public void MoveBackward()
    {
        rb.MovePosition(rb.position - (transform.forward * data.backwardSpeed * Time.deltaTime));
    }

    // Rotate right and left at degrees per second
    public void RotateRight()
    {
        transform.Rotate(0, -data.turnSpeed * Time.deltaTime, 0);
    }

    public void RotateLeft()
    {
        transform.Rotate(0, data.turnSpeed * Time.deltaTime, 0);
    }

    public void Spin()
    {
        transform.Rotate(0, 180, 0);
    }
}
