using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
#region Lootable Objects and Obstacles

    [Header("Objects Spawn Parameters")]
    public WeaponItem[] lootableWeapons;
    public AmmoItem[] lootableAmmos;
    public GameObject[] obstacleObjects;

    [Header("Spawn Area Parameters")]
    public GameObject worldSpawnBox;
    MeshCollider spawnBox;

    [Header("Spawning Parameters")]
    public float numOfSpawnedWorldObstacles;
    public int numOfSpawnedAmmos;
    public int numOfSpawnedWeapons;
    public int numOfSpawnWeapsAndAmmos;



#endregion

#region Enemy AI 

    // [Header("Enemy Parameters")]
    // public GameObject enemyPrefab;
    // public int numOfSpawnedEnemies;

#endregion

#region Unity Functions

    void Start()
    {
        spawnBox = worldSpawnBox.GetComponent<MeshCollider>();
        StartSpawning();
    }
    

#endregion

#region Spawning Lootables and World Obstacles

    public void StartSpawning()
    {
        // replace the current with the new one
        // insert parameters when spawning
        for (int i = 0; i < numOfSpawnedAmmos; i++) // spawning ammos
           Spawn(lootableAmmos[Random.Range(0, lootableAmmos.Length)].gameObject);

        for (int i=0; i < numOfSpawnedWeapons; i++)
           Spawn(lootableWeapons[Random.Range(0, lootableWeapons.Length)].gameObject);

        for (int i = 0; i < numOfSpawnedWorldObstacles; i++)
            Spawn(obstacleObjects[Random.Range(0, obstacleObjects.Length)].gameObject);

    }

    public void Spawn(GameObject prefabToSpawn)
    {
        float spawnPosX = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x);
        float spawnPosY = Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y);

        Vector2 pos = new Vector2(spawnPosX, spawnPosY);

        GameObject spawnedObject = Instantiate(prefabToSpawn, pos, Quaternion.identity);
        spawnedObject.transform.SetParent(this.transform);

    }

#endregion

}
