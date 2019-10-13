using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int wood = 0;
    public int iron = 0;
    public int stone = 0;

    int PlayerID = -1;

    private void Start()
    {
        if (gameObject.name == "Player1(Clone)") PlayerID = 0;
        if (gameObject.name == "Player2(Clone)") PlayerID = 1;
        Debug.Log(PlayerID);
    }

    public void AddResource(int amount, string id)
    {
        switch(id)
        {
            case "tree":
                wood += amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 0](wood);
                break;
            case "rock":
                stone += amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 1](stone);
                break;
            case "ore":
                iron += amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 2](iron);
                break;
            default:
                break;
        }
    }

    public void RemoveResource(int amount, string id)
    {
        switch (id)
        {
            case "tree":
                wood -= amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 0](wood);
                break;
            case "rock":
                stone -= amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 1](stone);
                break;
            case "ore":
                iron -= amount;
                if (PlayerID >= 0) HUDManager.Delegates[PlayerID, 2](iron);
                break;
            default:
                break;
        }
    }

    public int GetWood()
    {
        return wood;
    }

    public int GetIron()
    {
        return iron;
    }

    public int GetStone()
    {
        return stone;
    }
}
