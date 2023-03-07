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
        // insert parameters when spawning
        for (int i = 0; i < numOfSpawnedAmmos; i++) // spawning ammos
        {
            SpawnAmmos(lootableAmmos[Random.Range(0, lootableAmmos.Length)].gameObject);
        }

        for (int i=0; i < numOfSpawnedWeapons; i++)
        {
            SpawnWeapons(lootableWeapons[Random.Range(0, lootableWeapons.Length)].gameObject);
        }

        SpawnWorldObstacles(); // spawning the world obstacles
    }

    private void SpawnAmmos(GameObject ammoSpawn)
    {
        float spawnPosX = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x);
        float spawnPosY = Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y);

        Vector2 pos = new Vector2(spawnPosX, spawnPosY);

        GameObject spawnedAmmo = Instantiate(ammoSpawn, pos, Quaternion.identity);
        spawnedAmmo.transform.SetParent(this.transform);

    }

    private void SpawnWeapons(GameObject weaponSpawn)
    {
        float spawnPosX = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x);
        float spawnPosY = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.y);

        Vector2 pos = new Vector2(spawnPosX, spawnPosY);

        GameObject spawnedWeapon = Instantiate(weaponSpawn, pos, Quaternion.identity);
        spawnedWeapon.transform.SetParent(this.transform);
    }

    private void SpawnWorldObstacles()
    {
        for (int i=0; i < numOfSpawnedWorldObstacles; i++)
        {
            float spawnPosX = Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x);
            float spawnPosY = Random.Range(spawnBox.bounds.min.y, spawnBox.bounds.max.y);

            Vector2 pos = new Vector2(spawnPosX, spawnPosY);

            GameObject spawnedWorldObstacles = Instantiate(obstacleObjects[Random.Range(0, obstacleObjects.Length)],
                pos, Quaternion.identity);
            spawnedWorldObstacles.transform.SetParent(this.transform);
        }
    }

#endregion

}
