using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapManager))]
public class GameManager: MonoBehaviour
{
    private static GameManager gameManager;

    public List<GameObject> Players = new List<GameObject>();

    private bool Enabled = false;

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
                    gameManager = ManagerObject.AddComponent<GameManager>();
                }
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
}
