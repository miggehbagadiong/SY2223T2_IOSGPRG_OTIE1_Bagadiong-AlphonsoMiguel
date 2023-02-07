using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField, HideInInspector] public bool isGameActive = true;

    // SpawnPoint
    [Header("Spawn Parameters")]
    public GameObject spawnPoint;
    public float spawnRate;
    public float spawnDelayTime; // Set to 5f
    [HideInInspector] public float enemySpawnVal;

    // Enemy GameObject
    [Header("Enemy Parameters")]
    public GameObject spawnedEnemy;

    // What to Spawn
    int randomDirection;
    int enemyToSpawn;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        while (isGameActive)
        {
            randomDirection = Random.Range(1, 4);
            enemyToSpawn = Random.Range(1, 15);

            if (enemyToSpawn >= 1 && enemyToSpawn <= 5)
            {
                // Spawn Normal Arrow
                Debug.Log("Spawn Normal Arrow");

                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection);
                newEnemy.GetComponentInChildren<Arrow>().SetArrowRender(randomDirection, true);
            }
            else if (enemyToSpawn >= 6 && enemyToSpawn <= 10)
            {
                // Spawn Inverted Arrow
                Debug.Log("Spawn Inverted Arrow");

                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection);
                newEnemy.GetComponentInChildren<Arrow>().SetArrowRender(randomDirection, false);
            }
            else if (enemyToSpawn >= 11 && enemyToSpawn <= 15)
            {
                // Spawn Rotating Arrow
                Debug.Log("Spawn Rotating Arrow");

                GameObject newEnemy = Instantiate(spawnedEnemy, spawnPoint.transform.position, Quaternion.identity); 
                newEnemy.GetComponent<Enemy>().SetArrowDirection(randomDirection);
                newEnemy.GetComponent<Enemy>().CheckArrowDirection(randomDirection);
                newEnemy.GetComponentInChildren<Arrow>().SetRotateArrowRender(randomDirection);

            }

            yield return new WaitForSeconds(spawnDelayTime);
        }
    }
}
