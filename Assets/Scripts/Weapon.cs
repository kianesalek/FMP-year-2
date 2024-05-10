using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldownDuration = 1.0f;


    private float lastDestructionTime;

    void Start()
    {

        lastDestructionTime = -cooldownDuration;  
    }

    void OnCollisionEnter(Collision collision)
    {
        TryDestroyZombie(collision.gameObject);
    }

 
    void OnTriggerEnter(Collider other)
    {
        TryDestroyZombie(other.gameObject);
    }
    void TryDestroyZombie(GameObject gameObject)
    {
        if (gameObject.CompareTag("Zombies"))
        {
            float timeSinceLastDestruction = Time.time - lastDestructionTime;

            if (timeSinceLastDestruction >= cooldownDuration)
            {
                Destroy(gameObject);
                lastDestructionTime = Time.time;
            }
        }
    }
}
