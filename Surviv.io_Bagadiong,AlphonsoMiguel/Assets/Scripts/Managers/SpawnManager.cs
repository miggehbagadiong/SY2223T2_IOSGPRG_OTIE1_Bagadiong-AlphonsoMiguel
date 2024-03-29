using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
#region Lootable Objects and Obstacles

    [Header("Objects Spawn Parameters")]
    public WeaponItem[] lootableWeapons;
    public AmmoItem[] lootableAmmos;

    [Header("Spawn Area Parameters")]
    public GameObject worldSpawnBox;
    MeshCollider spawnBox;

    [Header("Spawning Parameters")]
    public int numOfSpawnedAmmos;
    public int numOfSpawnedWeapons;

#endregion

#region Enemy AI 

    [Header("Enemy Parameters")]
    public GameObject enemyPrefab;
    public int numOfSpawnedEnemies;

    [Header("Weapon Initializing Parameters")]
    public Weapon[] enemyWeapons;
    private int randWeaponVal;

    [Header("Unit List")]
    private List<Unit> diffUnits = new List<Unit>();

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

        // will spawn enemy and initialize with the weapon
        for (int i = 0; i < numOfSpawnedEnemies; i++)
        {
            Spawn(enemyPrefab);
        }
            

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

    public Weapon GetWeaponForEnemy()
    {
        return enemyWeapons[Random.Range(0, 2)];
    }

}
