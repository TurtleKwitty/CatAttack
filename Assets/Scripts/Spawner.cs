using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Transform player;

    public float RoundTime = 5;
    public float RoundTimer = 0;

    public int round = 1;

    public GameObject[] MonsterChoices;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            if (GameManager.Instance.Players[0] != null)
            {
                player = GameManager.Instance.Players[0].transform;
            }
        }
        else
        {
            RoundTimer += Time.deltaTime;
            if (RoundTimer > RoundTime)
            { // Time for next wave
                Spawn();
                RoundTimer -= RoundTime;
            }
        }
    }

    void Spawn()
    {
        for (int i = 0; i < round * round; i++)
        {
            int Choice = Random.Range(0, MonsterChoices.Length - 1);
            Debug.Log(MonsterChoices[Choice]);
            //TODO: Set position to something that makes more sense for the final game
            Vector2 Position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            Instantiate(MonsterChoices[Choice], Position, Quaternion.identity).GetComponent<Monster>().Init(player);
        }
        round++;
    }
}
