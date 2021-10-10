using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam.fieldOfView = 120;
        cam.rect = new Rect(0, 0.5f, 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
