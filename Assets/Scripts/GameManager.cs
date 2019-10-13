using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapManager))]
public class GameManager: MonoBehaviour
{
    private static GameManager gameManager;
    private static Spawner spawner;

    public Spawner SpawnerPrefab;

    public List<GameObject> Players = new List<GameObject>();

    public float RoundTime = 60;

    private bool Enabled = false;

    private int frame = 0;

    public static GameManager Instance
    {
        get{
            if(gameManager == null)
            {
                var Instance = FindObjectOfType<GameManager>();
                if (Instance == null)
                {
                    var ManagerObject = GameObject.FindGameObjectWithTag("GameController");
                    if (ManagerObject == null)
                    {
                        ManagerObject = new GameObject();
                    }
                    Instance = ManagerObject.AddComponent<GameManager>();
                }
                gameManager = Instance;
            }
            return gameManager;
        }
    }

    public void OnEnable()
    {
        if (Enabled == false)
        {
            if (gameManager == null) gameManager = this;
            gameObject.name = "GameManager";
            gameObject.tag = "GameController";
            DontDestroyOnLoad(gameObject);
            Enabled = true;
        }
    }

    public void RegisterPlayer(GameObject player)
    {
        Players.Add(player);
    }

    public void StartGame()
    {
        if(spawner != null)
        {
            Destroy(spawner);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Instantiate(SpawnerPrefab, transform);
    }
}
