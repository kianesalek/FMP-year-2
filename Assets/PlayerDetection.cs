using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    static public bool found = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBody")
        {
            found = true;
            print("Player detected");
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        found = false;
    }
}
