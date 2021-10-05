using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // add enemies to arraylist on game start
        GameManager.instance.EnemySpawners.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
