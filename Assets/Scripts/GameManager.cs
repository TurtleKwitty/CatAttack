using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    private static GameManager gameManager;

    public List<GameObject> Players = new List<GameObject>();

    public static GameManager Instance
    {
        get{
            if(gameManager == null)
            {
                var Instance = FindObjectOfType<GameManager>();
                if (Instance == null)
                {
                    var ManagerObject = new GameObject();
                    ManagerObject.name = "GameManager";
                    gameManager = ManagerObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(ManagerObject);
                }
            }
            return gameManager;
        }
    }

    public void RegisterPlayer(GameObject player)
    {
        Players.Add(player);
    }
}
