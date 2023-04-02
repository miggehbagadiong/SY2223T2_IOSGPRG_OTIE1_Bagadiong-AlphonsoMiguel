using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    #region Accessible Variables

    [Header("Patrol Spot Reference")]
    public PatrolSpot patrolSpots;

    // Parameters for checking the kill counts
    [HideInInspector]public int totalEnemyKills;

    void Start()
    {

    }

    #endregion

    #region Button Functions

    public void OnShootButtonPressed()
    {
        WeaponInventory.Instance.Shoot();
    }

    public void OnReloadButtonPressed()
    {
        WeaponInventory.Instance.Reload();
    }

    public void OnPrimaryButtonPressed()
    {
        WeaponInventory.Instance.SwitchWeapon("primary");
    }

    public void OnSecondaryButtonPressed()
    {
        WeaponInventory.Instance.SwitchWeapon("secondary");
    }

    #endregion

    #region Killing System
    public void AddEnemyKills()
    {
        totalEnemyKills++;
    }

    public void CheckKills()
    {
        if (totalEnemyKills == SpawnManager.Instance.numOfSpawnedEnemies)
        {
            Debug.Log("All enemies killed!");
            // call to event of the condition
        }
    }

    #endregion
}
