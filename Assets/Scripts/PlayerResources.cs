using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int wood = 0;
    public int iron = 0;
    public int stone = 0;

    public void AddResource(int amount, string id)
    {
        switch(id)
        {
            case "tree":
                wood += amount;
                break;
            case "ore":
                iron += amount;
                break;
            case "rock":
                stone += amount;
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
