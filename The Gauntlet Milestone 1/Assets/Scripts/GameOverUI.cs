using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    // create texts
    public Text HighScore;
    public Text Player1Score;
    public Text Player2Score;

    // reset score value
    public int resetPrefs = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Get Texts to display
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        Player1Score.text = "Player 1 Score: " + PlayerPrefs.GetInt("Player 1 Score");
        Player2Score.text = "Player 2 Score: " + PlayerPrefs.GetInt("Player 2 Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // restart game and scores
    public void RestartGame()
    {
        PlayerPrefs.SetInt("Player 1 Score", resetPrefs);
        PlayerPrefs.SetInt("Player 2 Score", resetPrefs);
        SceneManager.LoadScene("Start Menu");
    }
}
