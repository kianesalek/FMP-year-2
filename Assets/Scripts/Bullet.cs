using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

    void Start()
    {
        // Destroy the bullet after its lifetime adjusted for the time scale
        Destroy(gameObject, life / Time.timeScale);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombies"))
        {
            // Destroy the zombie and the bullet
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
