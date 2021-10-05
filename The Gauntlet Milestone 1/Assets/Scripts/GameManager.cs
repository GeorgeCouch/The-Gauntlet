using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The GameManager should cause the player to spawn at a random one of the playerSpawn locations each time the player dies

// The GameManager should spawn 4 AI tanks, each with a different personality, at random spawn points

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Player Scores
    public int Player1Score = 0;
    public int Player2Score = 0;

    // Array of tank data and tanks
    public TankData[] tanks;
    public GameObject[] gameObjects;
    public List<InputController> players;

    // List of powerups
    public List<GameObject> PowerUps;

    // List of Enemy Spawns
    public List<GameObject> EnemySpawners;
    public GameObject EnemyTank;
    public GameObject spawnedTank;
    public int tankAmount = 4;
    private List<AIGuardController.AIStates> states;

    // List of Player Spawns
    public List<GameObject> PlayerSpawners;
    public GameObject PlayerTank;
    public GameObject SpawnedPlayer;

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
        // Add states to array
        states = new List<AIController.AIStates>();
        states.Add(AIController.AIStates.FleeStatic);
        states.Add(AIController.AIStates.ChaseStatic);
        states.Add(AIController.AIStates.Idle);
        states.Add(AIController.AIStates.TurnAndShootStatic);
        // Wait 1 second for lists to be created
        StartCoroutine(WaitBeforeSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Respawn
    public void OnPlayerDie()
    {
        StartCoroutine(WaitBeforeSpawn());
    }

    IEnumerator WaitBeforeSpawn()
    {
        // Wait 1 second
        yield return new WaitForSeconds(1);

        // Choose spawn point, spawn player, assign input controller
        if (players != null)
        {
            int spawnNum = Random.Range(0, PlayerSpawners.Count);
            SpawnedPlayer = Instantiate(PlayerTank, PlayerSpawners[spawnNum].transform.position, Quaternion.identity) as GameObject;
            players[0].GetComponent<InputController>().myObjectData = SpawnedPlayer.GetComponent<TankData>();
        }

        // spawn tanks, assign states
        if (EnemySpawners.Count >= tankAmount)
        {
            for (int i = 0; i < 4; i++)
            {
                spawnedTank = Instantiate(EnemyTank, EnemySpawners[i].transform.position, Quaternion.identity) as GameObject;
                spawnedTank.GetComponentInChildren<AIGuardController>().ChangeState(states[i]);
            }
        }
        else
        {
            for (int i = 0; i < EnemySpawners.Count; i++)
            {
                spawnedTank = Instantiate(EnemyTank, EnemySpawners[i].transform.position, Quaternion.identity) as GameObject;
                spawnedTank.GetComponentInChildren<AIGuardController>().ChangeState(states[i]);
            }
        }
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
