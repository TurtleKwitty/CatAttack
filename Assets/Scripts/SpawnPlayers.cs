using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    [SerializeField] private List<GameObject> radMenus;
    [SerializeField] private Transform canvas;
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
            menu.transform.SetParent(canvas, false);

            player.GetComponent<RadialMenu>().radialMenu = menu;
            player.GetComponent<RadialMenu>().rectTransform = menu.GetComponent<RectTransform>();

            //player.name = players[i].name;
           // menu.name = radMenus[i].name;
            //menu.GetComponent<RMF_RadialMenu>().canExecuteOnClick = false;
            
            menu.SetActive(false);
        }
    }
}
