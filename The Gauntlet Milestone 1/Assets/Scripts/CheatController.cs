using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : MonoBehaviour
{
    public PowerUpController powCon;
    public Powerup cheatPowerup;

    // Start is called before the first frame update
    void Start()
    {
        if (powCon == null)
        {
            powCon = gameObject.GetComponent<PowerUpController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If H and U are down and this is the first frame that E is pressed
        if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.U) && Input.GetKeyDown(KeyCode.E))
        {
            // Add our powerup to the tank
            powCon.Add(cheatPowerup);
        }
    }
}
