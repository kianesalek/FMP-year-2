using UnityEngine;
using System.Collections;

public class Zombies : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips
    private AudioSource audioSource; // AudioSource component reference
    public float fadeOutDuration = 1.5f; // Duration for the fade-out effect in seconds

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to the zombie
        audioSource = GetComponent<AudioSource>();

        // Play a random audio clip immediately upon spawn
        PlayRandomAudioClip();
    }

    // Plays a random audio clip from the audioClips array
    void PlayRandomAudioClip()
    {
        // Check if there are any audio clips to play
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips available to play.");
            return;
        }

        // Choose a random index from the audioClips array
        int randomIndex = Random.Range(0, audioClips.Length);

        // Set the AudioSource's clip to the selected audio clip and play it
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
    }

    // Method to fade out the audio when the player dies
    public void FadeOutAudio()
    {
        // Start the coroutine to fade out the audio
        StartCoroutine(FadeOutCoroutine());
    }

    // Coroutine to fade out the audio over a specified duration
    IEnumerator FadeOutCoroutine()
    {
        float startVolume = audioSource.volume; // Store the initial volume

        // Gradually decrease the volume over the fade-out duration
        for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
        {
            // Interpolate the volume from the start volume to 0 over time
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeOutDuration);
            yield return null;
        }

        // Ensure the volume is set to 0 and stop the audio
        audioSource.volume = 0f;
        audioSource.Stop();
    }
}
