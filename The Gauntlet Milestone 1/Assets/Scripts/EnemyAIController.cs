using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public GameObject projectile;
    private TankData data;
    public float TimeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        data = this.gameObject.GetComponent<TankData>();
        InvokeRepeating("Shoot", 0, TimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        GameObject Bullet = Instantiate(projectile, transform.position + transform.forward + new Vector3(0, 0.3f, 0), transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, data.bulletSpeed));
        Object.Destroy(Bullet, data.BulletDestroy);
    }
}
