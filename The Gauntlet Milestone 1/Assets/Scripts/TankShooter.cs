using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public GameObject projectile;
    private TankData data;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        data = this.gameObject.GetComponent<TankData>();
        // Set canShoot to true
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Shoot if canShoot is true. Wait for specified time by designers before being able to shoot again
    public void Shoot()
    {
        if (canShoot)
        {
            GameObject Bullet = Instantiate(projectile, transform.position + transform.forward + new Vector3(0, 0.3f, 0), transform.rotation) as GameObject;
            Bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, data.bulletSpeed));
            Object.Destroy(Bullet, data.BulletDestroy);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(data.ShootDelay);
        canShoot = true;
    }
}
