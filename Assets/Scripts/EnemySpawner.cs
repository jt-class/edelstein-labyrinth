using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 10f;

    [SerializeField] private List<Waves> waves;


    private float spawnTimer;
    private float suddenTimer;
    private int suddenEnemyCount = 0;
    private int overallSpawnCount = 0; //total enemies spawned
    private int currentWave = 0; //Current wave
    [System.Serializable]

    public class Waves
    {
        public string waveName; // For debugging purposes
        public List<EnemyGroup> enemyGroups; //Enemy groups
        public int waveQuota; //Monster Quota
        public int spawnCount; //Amount of total enemy spawned on that wave
        public float spawnInterval;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public Transform Prefab; //The enemy to spawn
        public int SpawnCount; //Amount of enemy that already spawned
        public int SpawnQuota; //Quota for that enemy
    }


    private void Update()
    {
        spawnTimer += Time.deltaTime;
        suddenTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWave].spawnInterval)
        {
            if (transform.childCount <= waves[currentWave].waveQuota)
            {
                waves[currentWave].spawnCount = transform.childCount;
                SpawnEnemies();
                if (waves[currentWave].spawnCount >= waves[currentWave].waveQuota)
                {
                    spawnTimer += Time.deltaTime;
                }
            }
        }
        if (suddenTimer >= 10f)
        {
            WaveSpawn();
        }

    }

    private void SpawnEnemies() //Used for slow adding of enemies like 1 by 1 for each enemy that are killed
    {
        if (waves[currentWave].spawnCount < waves[currentWave].waveQuota) //If we still haven't reach the current quota
        {
            foreach (EnemyGroup enemyGroup in waves[currentWave].enemyGroups)
            {
                if (enemyGroup.SpawnCount < enemyGroup.SpawnQuota)
                {
                    Transform enemy = Instantiate(enemyGroup.Prefab, GetRandomSpawnPosition(), Quaternion.identity);
                    enemyGroup.SpawnCount++;
                    waves[currentWave].spawnCount++;
                    enemy.GetComponent<AIChase>().player = player.gameObject;
                    enemy.GetComponent<AIChase>().speed -= Random.Range(0f, 1f);
                    enemy.SetParent(gameObject.transform);
                }
            }
        }
    }
    private void WaveSpawn() //Used for sudden drop of many enemies at once
    {
        foreach (EnemyGroup enemyGroup in waves[currentWave].enemyGroups)
        {
            if (enemyGroup.SpawnCount < enemyGroup.SpawnQuota)
            {
                Transform enemy = Instantiate(enemyGroup.Prefab, GetRandomSpawnPosition(), Quaternion.identity);
                enemy.GetComponent<AIChase>().player = player.gameObject;
                enemy.GetComponent<AIChase>().speed -= Random.Range(0f, 1f);
                suddenEnemyCount++;
                Debug.Log(suddenEnemyCount);
            }
        }
        if (suddenEnemyCount >= waves[currentWave].waveQuota)
        {
            suddenTimer = 0f;
            suddenEnemyCount = 0;
        }
    }
    private Vector2 GetRandomSpawnPosition()
    {
        // Generate a random angle in a circle
        float angle = Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        Vector2 spawnDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Calculate the spawn position by adding the direction vector to the player's position
        return (Vector2)player.position + spawnDirection * spawnRadius;
    }
}
