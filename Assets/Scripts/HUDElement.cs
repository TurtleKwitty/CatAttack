using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDElement : MonoBehaviour
{
    public int PlayerID;
    public int ResourceID;

    void UpdateHUDElement(int amount)
    {
        Debug.Log(ResourceID);
        GetComponent<TMPro.TextMeshProUGUI>().text = amount.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        HUDManager.Delegates[PlayerID, ResourceID] = UpdateHUDElement;
        Debug.Log(PlayerID);
        Debug.Log(ResourceID);
    }
}
