using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    bool lookat = false;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetection.found)
        {
            lookat = true;
        }
        if (lookat)
        {
            transform.LookAt(player.transform);
        }
    }       

}
