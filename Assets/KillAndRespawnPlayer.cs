using UnityEngine;

public class KillAndRespawnPlayer : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);

            RespawnObject();
        }
    }

    // Method to respawn the attached object at the specified respawn point
    void RespawnObject()
    {
        GameObject newObject = Instantiate(gameObject, respawnPoint.position, respawnPoint.rotation);

        newObject.AddComponent<LavaRespawn>();

    }
}