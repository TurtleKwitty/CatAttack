using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    [SerializeField] private List<GameObject> radMenus;
    private Transform canvas;
    private int numberOfPlayers;
    private Vector3 position;
    void Start()
    {
        position = Vector3.zero;
        position.x = -5f;
        numberOfPlayers = PlayersNumber.NumberOfPlayers;

        for(int i = 0; i <= numberOfPlayers; i++)
        {
            GameObject player = Instantiate(players[i], position, Quaternion.identity);
            position.x += 10f;

            GameObject menu = Instantiate(radMenus[i], Vector3.zero, Quaternion.identity);

            canvas = player.transform.GetChild(1);
            menu.transform.SetParent(canvas, false);

            player.GetComponent<RadialMenu>().radialMenu = menu;
            player.GetComponent<RadialMenu>().rectTransform = menu.GetComponent<RectTransform>();
            
            menu.SetActive(false);
        }
    }
}
