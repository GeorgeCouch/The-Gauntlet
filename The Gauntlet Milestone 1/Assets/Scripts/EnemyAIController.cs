using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    // Allow designer to select projectile
    public GameObject projectile;
    private TankData data;
    // Allow designer to set time between shots
    public float TimeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        data = this.gameObject.GetComponent<TankData>();
        // Repeat shoot function ever TimeBetweenShots
        InvokeRepeating("Shoot", 0, TimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Instantiates a bullet and launches it forward. Destroys after specified time BulletDestroy
    public void Shoot()
    {
        GameObject Bullet = Instantiate(projectile, transform.position + transform.forward + new Vector3(0, 0.3f, 0), transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, data.bulletSpeed));
        Object.Destroy(Bullet, data.BulletDestroy);
    }
}
