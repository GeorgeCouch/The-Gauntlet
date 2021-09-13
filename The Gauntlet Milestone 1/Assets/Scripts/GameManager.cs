using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Player1Score = 0;
    public int Player2Score = 0;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

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
