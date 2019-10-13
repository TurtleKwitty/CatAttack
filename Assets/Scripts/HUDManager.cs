using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateHUDElement(int amount);

public class HUDManager : MonoBehaviour
{
    public static UpdateHUDElement[,] Delegates;

    // Start is called before the first frame update
    void OnEnable()
    {
        Delegates = new UpdateHUDElement[2, 3];
    }
}
