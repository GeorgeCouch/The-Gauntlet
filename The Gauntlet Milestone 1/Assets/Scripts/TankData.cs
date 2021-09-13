using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    //Variables for parts of our tank
    public TankMover mover;
    public TankShooter shooter;
    // Variables for our tank in game
    public float forwardSpeed;
    public float backwardSpeed;
    public float turnSpeed;
    public float bulletSpeed;
    public float BulletDestroy;
    public float ShootDelay;
    public float MaxHealth;
    public float BulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        // Load the mover
        mover = this.gameObject.GetComponent<TankMover>();
        // Load the shooter
        shooter = this.gameObject.GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MaxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            MaxHealth -= BulletDamage;
        }
    }
}

