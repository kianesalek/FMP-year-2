using UnityEngine;

public class Zombies : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float randomDelay = Random.Range(0f, 10f);
        Invoke(nameof(PlayRandomAudioClip), randomDelay);
    }

    void PlayRandomAudioClip()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips available to play.");
            return;
        }
        int randomIndex = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
    }
}