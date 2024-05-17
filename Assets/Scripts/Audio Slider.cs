using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float masterVolume = 1.0f;
    public AudioSource[] audioSources;

    void Start()
    {
        // Get all AudioSources in the scene
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        AudioListener.volume = masterVolume;
    }

    public void SetSFXVolume(float volume)
    {
        foreach (var source in audioSources)
        {
            // Check if the AudioSource is tagged as "SFX"
            if (source.CompareTag("SFX"))
            {
                source.volume = Mathf.Clamp01(volume);
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        foreach (var source in audioSources)
        {
            // Check if the AudioSource is tagged as "Music"
            if (source.CompareTag("Music"))
            {
                source.volume = Mathf.Clamp01(volume);
            }
        }
    }
}
