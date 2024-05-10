using UnityEngine;

public class DelayedAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private float delay = 3f;
    private float elapsedTime = 0f;
    private bool hasPlayed = false;

    void Update()
    {
        if (!hasPlayed)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= delay)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
    }
}
