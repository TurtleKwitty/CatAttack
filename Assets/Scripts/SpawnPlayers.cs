using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    private int numberOfPlayers;
    private Vector3 position;
    void Start()
    {
        position = Vector3.zero;
        position.x = -10f;
        numberOfPlayers = PlayersNumber.NumberOfPlayers;
        Debug.Log(numberOfPlayers);

        for(int i = 0; i <= numberOfPlayers; i++)
        {
            GameObject Player = Instantiate(players[i], position, Quaternion.identity);
            Player.name = players[i].name;
            position.x += 20f;
        }
    }
}
