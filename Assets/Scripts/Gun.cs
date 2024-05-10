using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private const float bulletCooldown = 0.2f;
    private float cooldownTimer = 0f;
    public AudioSource audioSource;

    void FixedUpdate()
    {
        // Adjust the cooldown timer based on the time scale
        cooldownTimer += Time.fixedDeltaTime / Time.timeScale;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cooldownTimer >= bulletCooldown)
            {
                // Instantiate a bullet
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                // Set the bullet's velocity and adjust for the time scale
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * bulletSpeed / Time.timeScale;
                }

                // Play the audio source
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                // Reset the cooldown timer
                cooldownTimer = 0f;
            }
        }
    }
}
