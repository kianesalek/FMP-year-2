using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip deathSoundClip;
    public AudioSource audioSource;
    public GameObject globalVolumeGameObject; // The global volume GameObject to be activated

    // This method is called when the player dies
    void PlayerDies()
    {
        // Log that the player dies
        Debug.Log("Player dies immediately.");

        // Play the death sound
        if (audioSource != null && deathSoundClip != null)
        {
            audioSource.PlayOneShot(deathSoundClip);
        }

        // Activate the global volume GameObject instantly
        if (globalVolumeGameObject != null)
        {
            globalVolumeGameObject.SetActive(true);
            Debug.Log("Global volume GameObject activated immediately.");
        }

        // Immediately destroy the player GameObject
        Destroy(gameObject);
    }

    // Method to handle collisions
    void OnCollisionEnter(Collision collision)
    {
        // If the collision is with a zombie, trigger the player's death
        if (collision.collider.CompareTag("Zombies"))
        {
            PlayerDies();
        }
    }
}
