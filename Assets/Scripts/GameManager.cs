using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Kill()
    {
        gameManager = null;
        spawner = null;
        MapManager.Instance.Kill();
        Destroy(gameObject);
        Destroy(this);
    }

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

    public void UnRegisterPlayer(GameObject player)
    {
        Debug.Log("Unreg");
        Players.Remove(player);
        if (Players.Count < 1) SceneManager.LoadScene("GameOver");
    }

    public void ReadyGame()
    {
        LoadManager.Ready = true;
    }

    public void StartGame()
    {
        if (spawner != null)
        {
            Destroy(spawner);
        }
        Instantiate(SpawnerPrefab, transform);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
