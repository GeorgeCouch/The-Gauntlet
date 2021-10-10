using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerTemp : MonoBehaviour
{
    // Get Texts
    public Text HighScore;
    public Text Player1Lives;
    public Text Player1Score;
    public Text Player2Lives;
    public Text Player2Score;

    // set high score value to zero for first time playing
    public int HighScoreValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get scores
        getHighScore();
        getPlayer1Lives();
        getPlayer1Score();
        getPlayer2Lives();
        getPlayer2Score();
        resetHighScore();

        // Load Game Over if H is pressed
        if (Input.GetKey(KeyCode.H))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Set high score
    public void getHighScore()
    {
        // check if player scores are higher than highscore value
        if (GameManager.instance.Player1Score > HighScoreValue || GameManager.instance.Player2Score > HighScoreValue)
        {
            // check if either player score is higher than highScore value
            if (GameManager.instance.Player1Score >= GameManager.instance.Player2Score)
            {
                HighScoreValue = GameManager.instance.Player1Score;
            }
            else
            {
                HighScoreValue = GameManager.instance.Player2Score;
            }

            // check if highscore value is greater than playerPref high score, if so then set PlayerPref
            if (HighScoreValue > PlayerPrefs.GetInt("High Score"))
            {
                PlayerPrefs.SetInt("High Score", HighScoreValue);
                PlayerPrefs.Save();
            }
        }
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
    }

    // Reset high score when needed
    public void resetHighScore()
    {
        if (Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.SetInt("High Score", 0);
            PlayerPrefs.Save();
        }
    }

    public void getPlayer1Lives()
    {
        Player1Lives.text = "Player 1 Lives: " + GameManager.instance.Player1Lives.ToString();
        PlayerPrefs.SetInt("High Score", GameManager.instance.Player1Lives);
        PlayerPrefs.Save();
    }

    public void getPlayer1Score()
    {
        Player1Score.text = "Player 1 Score: " + GameManager.instance.Player1Score.ToString();
        PlayerPrefs.SetInt("Player 1 Score", GameManager.instance.Player1Score);
        PlayerPrefs.Save();
    }

    public void getPlayer2Lives()
    {
        Player2Lives.text = "Player 2 Lives: " + GameManager.instance.Player2Lives.ToString();
        PlayerPrefs.SetInt("Player 2 Lives", GameManager.instance.Player2Lives);
        PlayerPrefs.Save();
    }

    public void getPlayer2Score()
    {
        Player2Score.text = "Player 2 Score: " + GameManager.instance.Player2Score.ToString();
        PlayerPrefs.SetInt("Player 2 Score", GameManager.instance.Player2Score);
        PlayerPrefs.Save();
    }
}
