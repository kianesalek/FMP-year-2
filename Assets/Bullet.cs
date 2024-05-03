using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;


    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("Zombies"))
        {
            Destroy(other.gameObject);
          
            Destroy(gameObject);
        }
       
    }

}