using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private const float bulletCooldown = 0.2f;
    private float cooldownTimer = 0f;

    // Add a reference to the AudioSource component
    public AudioSource audioSource;

    void FixedUpdate()
    {
        cooldownTimer += Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cooldownTimer >= bulletCooldown)
            {
                // Instantiate a bullet and set its velocity
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

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
