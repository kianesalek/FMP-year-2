using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private const float bulletCooldown = 0.5f;
    private float cooldownTimer = 0f;

    void FixedUpdate()
    {
        cooldownTimer += Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cooldownTimer >= bulletCooldown)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

                cooldownTimer = 0f;
            }
        }
    }
}
