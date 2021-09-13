using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Player Scores
    public int Player1Score = 0;
    public int Player2Score = 0;

    // Array of tank data and tanks
    public TankData[] tanks;
    public GameObject[] gameObjects;

    // Make singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Increment Score for either player if other player is dead. Do not increment if both players are dead
    public void Increment()
    {
        if (!GameObject.Find("Player1Tank") && GameObject.Find("Player2Tank"))
        {
            Player2Score++;
        }

        if (!GameObject.Find("Player2Tank") && GameObject.Find("Player1Tank"))
        {
            Player1Score++;
        }
    }    
}
