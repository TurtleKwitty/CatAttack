using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCheck : MonoBehaviour
{
    private void Start()
    {
        if(PlayersNumber.NumberOfPlayers < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
