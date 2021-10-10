using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public AudioClip MainTheme;
    public float MusicVol;

    // Start is called before the first frame update
    void Start()
    {
        // Play music
        ConvertPrefs();
        AudioSource.PlayClipAtPoint(MainTheme, gameObject.GetComponent<Transform>().position, MusicVol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Convert int to float by / 10
    public void ConvertPrefs()
    {
        MusicVol = PlayerPrefs.GetInt("Music Volume");
        MusicVol /= 10;
    }
}
