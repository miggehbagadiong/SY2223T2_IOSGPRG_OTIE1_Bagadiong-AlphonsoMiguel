using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

#region Accessible Variables

public PatrolSpot patrolSpots;

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
}
