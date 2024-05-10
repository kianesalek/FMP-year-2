using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip deathSoundClip;
    public AudioSource audioSource;
    public GameObject globalVolumeGameObject;
    public TMP_Text deathMessageText;
    public GameObject[] objectsToHide;
    public GameObject[] objectsToActivate;
    public FirstPersonLook firstPersonLook; 

    private string[] messages = {
        "Good job, loser!!",
        "Z-z-z-z-ZOMBIEEEE... oh sorry, wrong script.",
        "Mr. Branson is not happy with you...",
        "I guess you were not strong enough, lol!",
        "Good game! Sorry, no, that was terrible. Go play again.",
        "LOL LOSER"
    };

    void PlayerDies()
    {
        if (audioSource != null && deathSoundClip != null)
        {
            audioSource.PlayOneShot(deathSoundClip);
        }

        if (globalVolumeGameObject != null)
        {
            globalVolumeGameObject.SetActive(true);
        }

        if (objectsToHide != null)
        {
            foreach (GameObject obj in objectsToHide)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }

        if (objectsToActivate != null)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }

      
        if (firstPersonLook != null)
        {
            firstPersonLook.UnlockCursor();
        }

       
        if (deathMessageText != null)
        {
            int randomIndex = Random.Range(0, messages.Length);
            deathMessageText.text = messages[randomIndex];
            deathMessageText.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombies") || collision.collider.CompareTag("Lava"))
        {
            PlayerDies();
        }
    }

}
