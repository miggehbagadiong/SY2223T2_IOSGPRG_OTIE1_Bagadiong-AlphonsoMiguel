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

    [Header("Ui Canvases")]
    public GameObject gameCanvas;
    public GameObject chickenWinCanvas;

    private bool isFireButtonHeld = false;

    void Start()
    {
        // for the enemy death
        EventManager.Instance.OnEnemyDeath += AddEnemyKills;
        EventManager.Instance.OnEnemyDeath += CheckKills;

        // for the player death
        EventManager.Instance.OnPlayerDeath += GoToGameOver;

        // on start of this scene, set to game ui canvas
        SetActiveCanvas("game");
    }

    #endregion

    #region Button Functions

    public void OnShootButtonPressed()
    {
        WeaponInventory.Instance.Shoot();
    }

    public void OnShootButtonOnHold()
    {
        if (WeaponInventory.Instance.currWeapon.weaponType == WeaponType.Rifle)
        {
            isFireButtonHeld = true;
            WeaponInventory.Instance.Shoot();
        }  
    }

    public void OnShootButtonReleased()
    {
        isFireButtonHeld = false;
    }

    public bool GetIsFireButtonHeld()
    {
        return isFireButtonHeld;
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

    public void OnTryAgainButtonPressed()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
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
            SetActiveCanvas("chicken dinner");

        }
    }

    #endregion

    #region Scene Controller

    public void GoToGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void SetActiveCanvas(string activeCanvas)
    {
        if (activeCanvas == "game")
        {
            gameCanvas.SetActive(true);
            chickenWinCanvas.SetActive(false);
        }
        else if (activeCanvas == "chicken dinner")
        {
            gameCanvas.SetActive(false);
            chickenWinCanvas.SetActive(true);
        }
    }

    #endregion
}
