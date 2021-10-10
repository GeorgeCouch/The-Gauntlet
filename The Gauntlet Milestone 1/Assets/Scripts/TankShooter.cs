using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public AudioClip TankShoot;
    public float ShootVol;
    public GameObject projectile;
    private TankData data;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        ConvertPrefs();
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
            AudioSource.PlayClipAtPoint(TankShoot, gameObject.GetComponent<Transform>().position, ShootVol);
            GameObject Bullet = Instantiate(projectile, transform.position + transform.forward + new Vector3(0, 0.3f, 0), transform.rotation) as GameObject;
            Bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, data.bulletSpeed));
            Object.Destroy(Bullet, data.BulletDestroy);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    public void ConvertPrefs()
    {
        ShootVol = PlayerPrefs.GetInt("SFX Volume");
        ShootVol /= 10;
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(data.ShootDelay);
        canShoot = true;
    }
}
