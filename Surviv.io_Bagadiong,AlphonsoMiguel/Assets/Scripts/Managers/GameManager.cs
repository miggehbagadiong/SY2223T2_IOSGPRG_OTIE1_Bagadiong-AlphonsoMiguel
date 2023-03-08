using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        //SpawnManager.Instance.StartSpawning();
    }

    #region Button Functions

    public void OnShootButtonPressed()
    {
        WeaponInventory.Instance.Shoot();
    }

    public void OnReloadButtonPressed()
    {
        WeaponInventory.Instance.Reload();
    }

    #endregion
}
