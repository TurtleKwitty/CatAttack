using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public static bool Ready = false;
    bool Loading = true;

    // Update is called once per frame
    void Update()
    {
        if (Ready)
        {
            if (Loading)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (Input.GetButtonDown("BuildPlayer1"))
            {
                GameManager.Instance.StartGame();
            }
        }
    }
}
