using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    public Text Player1Lives;
    public Text Player1Score;
    public Text Player2Lives;
    public Text Player2Score;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player1Lives.text = "Lives: " + GameManager.instance.Player1Lives.ToString();
        Player1Score.text = "Player 1 Score: " + GameManager.instance.Player1Score.ToString();
        Player2Lives.text = "Lives: " + GameManager.instance.Player2Lives.ToString();
        Player2Score.text = "Player 2 Score: " + GameManager.instance.Player2Score.ToString();
        HighScore.text = "High Score: " + GameManager.instance.HighScore.ToString();
    }
}
