using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    #region Accessible Variables

    [Header("Patrol Spot Reference")]
    public PatrolSpot patrolSpots;

    // Parameters for checking the kill counts
    [HideInInspector]public int totalEnemyKills;

    void Start()
    {
        // for the enemy death
        EventManager.Instance.OnEnemyDeath += AddEnemyKills;
        EventManager.Instance.OnEnemyDeath += CheckKills;

        // for the player death
        EventManager.Instance.OnPlayerDeath += GoToGameOver;
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
        Debug.Log("Enemy Kills: " + totalEnemyKills);
    }

    public void CheckKills()
    {
        if (totalEnemyKills == SpawnManager.Instance.numOfSpawnedEnemies)
        {
            Debug.Log("All enemies killed! Player Won!");
            // call to event of the condition
            Time.timeScale = 0; // use this when its winner winner chicken dinner

        }
    }

    #endregion

    #region Scene Controller

    public void GoToGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    #endregion
}
