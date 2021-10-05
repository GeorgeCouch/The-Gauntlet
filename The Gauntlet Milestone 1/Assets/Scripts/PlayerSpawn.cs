using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Add players to array list on game start
        GameManager.instance.PlayerSpawners.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
