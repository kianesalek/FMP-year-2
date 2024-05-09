using System.Collections;
using UnityEngine;
using TMPro; // Add this using directive for TextMesh Pro

public class SlowTimeAbility : MonoBehaviour
{
    public float abilityDuration = 5f;
    public float abilityCooldown = 45f;
    public float slowTimeScale = 0.6f;
    private bool abilityOnCooldown = false;
    private float cooldownTimer = 0f;
    public GameObject blackAndWhiteEffectObject;
    public AudioClip abilitySoundClip;
    public AudioSource audioSource;

    // Add a public TMP_Text variable to reference the TextMesh Pro text label
    public TMP_Text cooldownTextLabel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !abilityOnCooldown)
        {
            StartCoroutine(ActivateSlowTimeAbility());
        }

        if (abilityOnCooldown)
        {
            cooldownTimer += Time.deltaTime;

            // Calculate the remaining cooldown time
            float remainingCooldownTime = abilityCooldown - cooldownTimer;

            // Update the text label to display the remaining cooldown time
            cooldownTextLabel.text = $"Q ability cooldown: {remainingCooldownTime:F1}";

            if (cooldownTimer >= abilityCooldown)
            {
                cooldownTimer = 0f;
                abilityOnCooldown = false;

                // Reset the text label when cooldown is over
                cooldownTextLabel.text = string.Empty;
            }
        }
    }

    IEnumerator ActivateSlowTimeAbility()
    {
        abilityOnCooldown = true;
        blackAndWhiteEffectObject.SetActive(true);
        audioSource.PlayOneShot(abilitySoundClip);

        Time.timeScale = slowTimeScale;
        yield return new WaitForSecondsRealtime(abilityDuration);

        Time.timeScale = 1f;
        blackAndWhiteEffectObject.SetActive(false);
    }
}
