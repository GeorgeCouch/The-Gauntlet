using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Powerup powerup;
    public AudioClip feedback;
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    public GameObject spawnedPickup;

    // Start is called before the first frame update
    void Start()
    {
        // Add to list on start
        GameManager.instance.PowerUps.Add(pickupPrefab);
        // Get transform of spawnPoint
        tf = gameObject.GetComponent<Transform>();
        // Get first SpawnTime for pickup
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If spawnedPickup is empty, then player has picked up pickup
        if (spawnedPickup == null)
        {
            // if nextSpawnTime is valid because time hasn't passed it
            if (Time.time > nextSpawnTime)
            {
                // Spawn pickup and reset delay
                spawnedPickup = Instantiate(pickupPrefab, tf.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
                // Reset duration to half a second less than spawn delay, use spawn delay to define duration
                powerup.duration = spawnDelay -.05f;
            }
        }
        else
        {
            // Otherwise, the object still exists, so postpone the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (spawnedPickup != null)
        {
            // variable to store other object's PowerupController - if it has one
            PowerUpController powCon = other.GetComponent<PowerUpController>();

            // If the other object has a PowerupController
            if (powCon != null)
            {
                // Add the powerup
                powCon.Add(powerup);

                // Play Feedback (if it is set)
                if (feedback != null)
                {
                    AudioSource.PlayClipAtPoint(feedback, gameObject.GetComponent<Transform>().position, 1.0f);
                }

                // Destroy this pickup
                Destroy(spawnedPickup);
            }
        }
    }
}
