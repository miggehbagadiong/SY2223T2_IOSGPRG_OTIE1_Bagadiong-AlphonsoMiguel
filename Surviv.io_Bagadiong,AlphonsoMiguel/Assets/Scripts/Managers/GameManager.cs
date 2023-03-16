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

    public void OnPrimaryButtonPressed()
    {
        WeaponInventory.Instance.SwitchWeapon("primary");
    }

    public void OnSecondaryButtonPressed()
    {
        WeaponInventory.Instance.SwitchWeapon("secondary");
    }

    #endregion
}
