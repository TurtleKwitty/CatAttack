using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    GameObject[] Targets;

    private void Start()
    {
        Targets = new GameObject[GameManager.Instance.Players.Count];
        for(var i = 0; i < Targets.Length; i++)
        {
            Targets[i] = GameManager.Instance.Players[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Target = Targets[0].transform.position;
        for(var i = 1; i < Targets.Length; i++)
        {
            Target += Targets[i].transform.position;
        }
        Target /= Targets.Length;

        gameObject.transform.position = Target;
    }
}
