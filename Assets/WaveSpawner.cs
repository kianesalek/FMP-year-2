using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro; // Import the Text Mesh Pro namespace

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public TMP_Text waveText;
    public AudioSource audioSource; // Add this line to declare an AudioSource
    public AudioClip waveChangeAudioClip; // Add this line to declare an AudioClip

    void Start()
    {
        GenerateWave();
        UpdateWaveText();
    }

    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity);
                enemy.SetActive(true);
                enemiesToSpawn.RemoveAt(0);
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                spawnIndex = (spawnIndex + 1) % spawnLocation.Length;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {
            currWave++;
            GenerateWave();
            UpdateWaveText();
            PlayWaveChangeAudio(); // Play the audio clip when a new wave starts
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;

        GenerateEnemies();
        spawnInterval = 2.0f;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            var validEnemies = enemies.FindAll(e => e.cost <= waveValue).ToList();
            if (validEnemies.Count == 0)
                break;
            int randEnemyId = Random.Range(0, validEnemies.Count);
            int randEnemyCost = validEnemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(validEnemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    void UpdateWaveText()
    {
        waveText.text = "Wave count is " + currWave;
    }

    void PlayWaveChangeAudio()
    {
        audioSource.PlayOneShot(waveChangeAudioClip);
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;

}
