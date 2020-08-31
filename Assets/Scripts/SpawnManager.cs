using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{

    public float movingSpeed = 1f;
    public float spawnInterval = 5f;
    public float zeroEnemyChance = 0.4f;
    public float twoEnemyChance = 0.2f;
    public float spawnReduction = .02f;
    public float chanceReduction = .005f;
    public List<GameObject> enemies;

    Transform spawnedEnemies;
    Transform[] spawnPoints;

    int numberOfEnemies;
    float nextSpawnTime;

    void Start()
    {
        Transform spawnPointManager = GameObject.Find("SpawnPoints").transform;
        spawnedEnemies = GameObject.Find("Enemies").transform;
        spawnPoints = new Transform[spawnPointManager.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = spawnPointManager.GetChild(i);
        }
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemies();
        }
        if (spawnedEnemies.childCount > 12)
        {
            Destroy(spawnedEnemies.GetChild(0));
        }

        // Look into removing oldest spawned enemies
    }

    void SpawnEnemies()
    {
        /*
        int numberOfEnemies = Random.Range(0, 3);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)],
            spawnPoints[Random.Range(0, spawnPoints.Length)]);
            newEnemy.transform.SetParent(spawnedEnemies);
        }
        nextSpawnTime = Time.time + spawnInterval;
        */

        float probability = Random.Range(0f, 1f);
        if (probability <= zeroEnemyChance)
            numberOfEnemies = 0;
        if (probability > zeroEnemyChance && probability < twoEnemyChance)
            numberOfEnemies = 1;
        if (probability >= twoEnemyChance)
            numberOfEnemies = 2;

        List<Transform> potentialSpawnPoints = spawnPoints.ToList();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform spawnPoint = potentialSpawnPoints[Random.Range(0, potentialSpawnPoints.Count)];
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoint);
            newEnemy.transform.SetParent(spawnedEnemies);
            //Vector3 spawnPointVector = new Vector3(spawnPoint.position.x, spawnPoint.position.y);
            //GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPointVector,
            //    Quaternion.identity, spawnedEnemies);
            // newEnemy.transform.SetParent(spawnedEnemies);
            potentialSpawnPoints.Remove(spawnPoint);
        }

        nextSpawnTime = Time.time + spawnInterval;
        
        if (zeroEnemyChance > .1f)
            zeroEnemyChance -= chanceReduction;
        if (spawnInterval > 2f)
            spawnInterval -= spawnReduction;
    }
}
