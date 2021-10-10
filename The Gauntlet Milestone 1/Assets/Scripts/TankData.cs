using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    public AudioClip TankDestroy;
    public float TankDestroyVol;
    //Variables for parts of our tank
    public TankMover mover;
    public TankShooter shooter;
    public GameManager gameManager;
    // Variables for our tank in game
    public float forwardSpeed;
    public float backwardSpeed;
    public float turnSpeed;
    public float bulletSpeed;
    public float BulletDestroy;
    public float ShootDelay;
    public float MaxHealth;
    public float BulletDamage;
    public float CurrentMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        ConvertPrefs();
        // Load the mover
        mover = this.gameObject.GetComponent<TankMover>();
        // Load the shooter
        shooter = this.gameObject.GetComponent<TankShooter>();
        // Load GameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MaxHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(TankDestroy, gameObject.GetComponent<Transform>().position, TankDestroyVol);
            Destroy(gameObject);
        }
    }

    // Call GameManager Increment if a tank is Destroyed
    private void OnDestroy()
    {
        gameManager.Increment();
    }

    // Take Damage if collide with a bullet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            MaxHealth -= BulletDamage;
        }
    }

    public void ConvertPrefs()
    {
        TankDestroyVol = PlayerPrefs.GetInt("SFX Volume");
        TankDestroyVol /= 10;
    }
}

