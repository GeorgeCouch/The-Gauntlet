using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public List<Powerup> powerups;
    public List<Powerup> PermanentPowerups;
    public TankData myObjectData;

    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create an List to hold our expired powerups
        List<Powerup> expiredPowerups = new List<Powerup>();

        // Loop through all the powers in the List
        foreach (Powerup power in powerups)
        {
            // Subtract from the timer
            power.duration -= Time.deltaTime;

            // Assemble a list of expired powerups
            if (power.duration <= 0)
            {
                expiredPowerups.Add(power);
            }
        }
        // Now that we've looked at every powerup in our list, use our list of expired powerups to remove the expired ones.
        foreach (Powerup power in expiredPowerups)
        {
            power.OnDeactivate(myObjectData);
            powerups.Remove(power);
        }
        // Since our expiredPowerups is local, it will *poof* into nothing when this function ends, 
        ///    but let's clear it to learn how to empty an List
        expiredPowerups.Clear();
    }

    public void Add(Powerup powerup)
    {
        powerup.OnActivate(myObjectData);
        // Only add the permanent ones to the list
        if (!powerup.isPermanent)
        {
            powerups.Add(powerup);
        }
        else
        {
            // Add to powerup list that doesn't account for duration if permanent
            PermanentPowerups.Add(powerup);
        }
    }
}
