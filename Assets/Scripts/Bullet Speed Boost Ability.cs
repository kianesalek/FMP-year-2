using UnityEngine;
using TMPro;
using System.Collections;

public class BulletSpeedBoostAbility : MonoBehaviour
{
    public float abilityDuration = 12f;
    public float abilityCooldown = 200f;
    public float bulletSpeedBoost = 200f;
    public float playerMoveSpeed = 13f;
    public float gunDelay = 0.05f;

    private bool abilityOnCooldown = false;
    private float cooldownTimer = 0f;
    public TMP_Text cooldownTextLabel;
    public AudioSource abilityAudioSource;
    public GameObject activationEffect;

    public Gun gunScript;
    public WaveSpawner waveSpawner; // Reference to the WaveSpawner script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !abilityOnCooldown && waveSpawner.currWave >= 10)
        {
            StartCoroutine(ActivateAbility());
        }

        if (abilityOnCooldown)
        {
            cooldownTimer += Time.deltaTime;
            float remainingCooldownTime = abilityCooldown - cooldownTimer;

            cooldownTextLabel.text = $"E ability cooldown: {remainingCooldownTime:F1}";

            if (cooldownTimer >= abilityCooldown)
            {
                cooldownTimer = 0f;
                abilityOnCooldown = false;

                cooldownTextLabel.text = string.Empty;
            }
        }
    }

    IEnumerator ActivateAbility()
    {
        abilityOnCooldown = true;

        if (abilityAudioSource != null)
        {
            abilityAudioSource.Play();
        }

        if (activationEffect != null)
        {
            activationEffect.SetActive(true);
        }

        if (gunScript != null)
        {
            gunScript.bulletSpeed = bulletSpeedBoost;
            gunScript.bulletDelay = gunDelay;
        }

        Time.timeScale = 1.5f;

        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = transform.forward * playerMoveSpeed;
        }

        yield return new WaitForSeconds(abilityDuration);

        Time.timeScale = 1f;

        if (gunScript != null)
        {
            gunScript.bulletSpeed = gunScript.originalBulletSpeed;
            gunScript.bulletDelay = gunScript.originalBulletDelay;
        }

        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        if (activationEffect != null)
        {
            activationEffect.SetActive(false);
        }
    }
}
