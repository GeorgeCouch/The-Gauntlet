using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Audio for button click
    public AudioClip buttonClip;

    // button Texts
    public Text SFXDisplay;
    public Text MusicDisplay;
    public Text MultiplayerDisplay;
    public Text MapDisplay;

    // Volumes and Choices
    public int SFXVolume = 0;
    public float SFXVolumeUse = 0;
    public int MusicVolume = 0;
    public float MusicVolumeUse = 0;
    public int multiplayerChoice = 1;
    public int mapChoice = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get Volumes and Choices
        SFXVolume = PlayerPrefs.GetInt("SFX Volume");
        MusicVolume = PlayerPrefs.GetInt("Music Volume");
        multiplayerChoice = PlayerPrefs.GetInt("Multiplayer Choice");
        mapChoice = PlayerPrefs.GetInt("Map Choice");
    }

    // Update is called once per frame
    void Update()
    {
        // Display Text if in Options screen
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Options")
        {
            SFXDisplay.text = SFXVolume.ToString();
            MusicDisplay.text = MusicVolume.ToString();
            if (multiplayerChoice == 1)
            {
                MultiplayerDisplay.text = "Multiplayer";
            }
            else
            {
                MultiplayerDisplay.text = "Singleplayer";
            }
            if (mapChoice == 1)
            {
                MapDisplay.text = "Map of the Day";
            }
            else
            {
                MapDisplay.text = "Random Map";
            }
        }
    }

    public void StartGame()
    {
        // Start Game Scene
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        SceneManager.LoadScene("Extras");
    }

    public void GameOptions()
    {
        // Go to options
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        SceneManager.LoadScene("Options");
    }

    public void BackToStart()
    {
        // Save settings and go to start menu
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        PlayerPrefs.SetInt("SFX Volume", SFXVolume);
        PlayerPrefs.SetInt("Music Volume", MusicVolume);
        PlayerPrefs.SetInt("Multiplayer Choice", multiplayerChoice);
        PlayerPrefs.SetInt("Map Choice", mapChoice);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Start Menu");
    }

    public void SFXVolumeDown()
    {
        // Turn SFX volume down
        if (SFXVolume != 0)
        {
            SFXVolume -= 1;
        }
        SFXVolumeSwitch();
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
    }

    public void SFXVolumeUp()
    {
        // Turn SFX Volume up
        if (SFXVolume != 10)
        {
            SFXVolume += 1;
        }
        SFXVolumeSwitch();
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
    }

    public void MusicVolumeDown()
    {
        // Turn music volume down
        if (MusicVolume != 0)
        {
            MusicVolume -= 1;
        }
        MusicVolumeSwitch();
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, MusicVolumeUse);
    }

    public void MusicVolumeUp()
    {
        // Turn music volume up
        if (MusicVolume != 10)
        {
            MusicVolume += 1;
        }
        MusicVolumeSwitch();
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, MusicVolumeUse);
    }

    public void ChangeMultiplayer()
    {
        // Change multiplayer choice
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        if (multiplayerChoice == 1)
        {
            multiplayerChoice = 0;
        }
        else
        {
            multiplayerChoice = 1;
        }
    }

    public void MapChoice()
    {
        // Change map choice
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        if (mapChoice == 1)
        {
            mapChoice = 0;
        }
        else
        {
            mapChoice = 1;
        }
    }

    public void QuitGame()
    {
        // Quit Game
        AudioSource.PlayClipAtPoint(buttonClip, gameObject.GetComponent<Transform>().position, SFXVolumeUse);
        Application.Quit();
    }

    public void SFXVolumeSwitch()
    {
        // Switch for SFX Volume accuracy
        switch (SFXVolume)
        {
            case 0:
                SFXVolumeUse = 0.0f;
                break;
            case 1:
                SFXVolumeUse = 0.1f;
                break;
            case 2:
                SFXVolumeUse = 0.2f;
                break;
            case 3:
                SFXVolumeUse = 0.3f;
                break;
            case 4:
                SFXVolumeUse = 0.4f;
                break;
            case 5:
                SFXVolumeUse = 0.5f;
                break;
            case 6:
                SFXVolumeUse = 0.6f;
                break;
            case 7:
                SFXVolumeUse = 0.7f;
                break;
            case 8:
                SFXVolumeUse = 0.8f;
                break;
            case 9:
                SFXVolumeUse = 0.9f;
                break;
            case 10:
                SFXVolumeUse = 1.0f;
                break;
        }
    }

    public void MusicVolumeSwitch()
    {
        // switch for music volume accuracy
        switch (MusicVolume)
        {
            case 0:
                MusicVolumeUse = 0.0f;
                break;
            case 1:
                MusicVolumeUse = 0.1f;
                break;
            case 2:
                MusicVolumeUse = 0.2f;
                break;
            case 3:
                MusicVolumeUse = 0.3f;
                break;
            case 4:
                MusicVolumeUse = 0.4f;
                break;
            case 5:
                MusicVolumeUse = 0.5f;
                break;
            case 6:
                MusicVolumeUse = 0.6f;
                break;
            case 7:
                MusicVolumeUse = 0.7f;
                break;
            case 8:
                MusicVolumeUse = 0.8f;
                break;
            case 9:
                MusicVolumeUse = 0.9f;
                break;
            case 10:
                MusicVolumeUse = 1.0f;
                break;
        }
    }
}
