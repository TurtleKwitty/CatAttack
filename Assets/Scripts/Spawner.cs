using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Transform player;

    public float RoundTime = 5;
    public float RoundTimer = 0;

    public GameObject[] MonsterChoices;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Players[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        //RoundTimer += Time.deltaTime;
        if(RoundTimer > RoundTime)
        { // Time for next wave
            Spawn();
            RoundTimer -= RoundTime;
        }
    }

    void Spawn()
    {
        int Choice = Random.Range(0, MonsterChoices.Length - 1);
        //TODO: Set position to something that makes more sense for the final game
        Vector2 Position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        Instantiate(MonsterChoices[Choice], Position, Quaternion.identity).GetComponent<Monster>().Init(player);
    }
}
