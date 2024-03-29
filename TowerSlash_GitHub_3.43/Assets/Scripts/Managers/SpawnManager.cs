using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField, HideInInspector] public bool isGameActive = true;

    // SpawnPoint
    [Header("Spawn Parameters")]
    public GameObject spawnPoint;
    public float spawnRate;
    public float maxSpawnDelayTime;
    private float spawnDelayTime; // Set to 5f
    [HideInInspector] public float enemySpawnVal;

    // Enemy GameObject
    [Header("Enemy Parameters")]
    public GameObject spawnedEnemy;
    [HideInInspector] public List<Enemy> enemies;

    // What to Spawn
    int randomDirection;
    int enemyToSpawn;

    // boolean
    public bool canStartRotating = false;

    void Start()
    {
        //StartSpawning();
        StartCoroutine(SpawnEnemy());
    }

    public void SetStartSpawning()
    {
        canStartRotating = true;
    }
    
    public void StartSpawning()
    {
        if (canStartRotating == true)
            StartCoroutine(SpawnEnemy());
    }

    public Enemy GetFirstEnemy()
    {
        return enemies[0];
    }

    public void RemoveEnemy()
    {
        enemies.RemoveAt(0);
    }

    public List<Enemy> GetEnemyList()
    {
        return enemies;
    }

    public IEnumerator SpawnEnemy()
    {
        Debug.Log("Spawning Enemy!");

        while (isGameActive)
        {
            randomDirection = Random.Range(1, 4);
            enemyToSpawn = Random.Range(1, 15);
            spawnDelayTime = Random.Range(1, maxSpawnDelayTime);

            if (enemyToSpawn >= 1 && enemyToSpawn <= 5)
            {
                // Spawn Normal Arrow
                Debug.Log("Spawn Normal Arrow");

                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection);
                newEnemy.GetComponentInChildren<Arrow>().SetArrowRender(randomDirection, true);

                enemies.Add(newEnemy.GetComponent<Enemy>());
            }
            else if (enemyToSpawn >= 6 && enemyToSpawn <= 10)
            {
                // Spawn Inverted Arrow
                Debug.Log("Spawn Inverted Arrow");

                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection);
                newEnemy.GetComponentInChildren<Arrow>().SetArrowRender(randomDirection, false);

                enemies.Add(newEnemy.GetComponent<Enemy>());

            }
            else if (enemyToSpawn >= 11 && enemyToSpawn <= 15)
            {
                // Spawn Rotating Arrow
                Debug.Log("Spawn Rotating Arrow");

                // recheck this somehow or what
                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity); 
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection); // sets the arrow direction
                newEnemy.GetComponent<Enemy>().InitializeRotatingArrows(randomDirection);
                StartCoroutine(newEnemy.GetComponentInChildren<Arrow>().RotateArrow(canStartRotating, randomDirection));
                enemies.Add(newEnemy.GetComponent<Enemy>());

            }

            yield return new WaitForSeconds(spawnDelayTime);
        }
    }
}
