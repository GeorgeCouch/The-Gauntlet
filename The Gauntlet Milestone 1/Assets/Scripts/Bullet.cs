using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip BulletDestroy;
    public float BulletDestroyVol;

    // Start is called before the first frame update
    void Start()
    {
        ConvertPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy Bullet if it collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(BulletDestroy, gameObject.GetComponent<Transform>().position, BulletDestroyVol);
        Destroy(gameObject);
    }

    public void ConvertPrefs()
    {
        BulletDestroyVol = PlayerPrefs.GetInt("SFX Volume");
        BulletDestroyVol /= 10;
    }
}
