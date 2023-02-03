using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField, HideInInspector] public bool isGameActive = true;

    // SpawnPoint
    public GameObject spawnPoint;

    // Enemy GameObject
    public GameObject enemy;

    // Spawning Parameters
    public float spawnRate;
    [HideInInspector] public float enemySpawnVal;
    public float spawnDelayTime; // Set to 5f

    // What to Spawn
    int randomDirection;


    void Start()
    {
        
    }



    #region Coroutines

    public IEnumerator SpawnAllEnemies()
    {
        yield return 0;
    }

    public IEnumerator SpawnEnemy()
    {
        yield return 0;
    }

    #endregion

}
