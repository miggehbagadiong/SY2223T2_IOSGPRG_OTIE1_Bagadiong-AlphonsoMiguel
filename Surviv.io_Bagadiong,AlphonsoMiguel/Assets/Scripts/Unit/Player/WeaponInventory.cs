using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : Singleton<WeaponInventory>
{
    // Weapon References
    [Header("Weapon References")]
    [SerializeField] GameObject wHeld; // means "Weapon Held"
    [SerializeField] Transform wMuzzle;
    [SerializeField] SpriteRenderer wGFX;
    [SerializeField] Weapon[] weaponsList;
    [SerializeField] Weapon primaryWeap;
    [SerializeField] Weapon secondaryWeap;
    [HideInInspector] public Weapon currWeapon;


   // [Header("Ammo References")]
    [HideInInspector] public int rifleMag;
    [HideInInspector] public int pistolMag;
    [HideInInspector] public int shotgunMag;

    [HideInInspector] int refData;

    private void Update()
    {
        if (currWeapon != null)
            UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);

    }

#region Ammo References

    public void AddPistolMag(int add)
    {
        pistolMag += add;
    }

    public void AddRifleMag(int add)
    {
        rifleMag += add;
    }

    public void AddShotgunMag(int add)
    {
        shotgunMag += add;
    }

    public void ReducePistolMag(int reduce)
    {
        pistolMag -= reduce;
    }

    public void ReduceRifleMag(int reduce)
    {
        rifleMag -= reduce;
    }

    public void ReduceShotgunMag(int reduce)
    {
        shotgunMag -= reduce;
    }

    public int GetAmmoMagData(Ammo ammoRef)
    {
        
        if (ammoRef.ammoType == AmmoType.Pistol)
            refData = pistolMag;
        else if (ammoRef.ammoType == AmmoType.Rifle)
            refData = rifleMag;
        else if (ammoRef.ammoType == AmmoType.Shotgun)
            refData = shotgunMag;

        return refData;

    }

    public int GetPistolMag()
    {
        return pistolMag;
    }

    public int GetRifleMag()
    {
        return rifleMag;
    }

    public int GetShotgunMag()
    {
        return shotgunMag;
    }

#endregion

#region Weapon Inventory Functions

    public Transform GetMuzzle()
    {
        return wMuzzle;
    }

    public void AddWeaponToInventory(Weapon newWeap) // adds either primary or secondary weapon
    {
      
        if ((newWeap.weaponType == WeaponType.Rifle || newWeap.weaponType == WeaponType.Shotgun) && !primaryWeap)
        {
            Debug.Log("Added weapon " + newWeap.weaponType.ToString());
            primaryWeap = newWeap;
           
            UiManager.Instance.SetInteractableWeapon("primary", true);
        }
        else if ((newWeap.weaponType == WeaponType.Pistol) && !secondaryWeap)
        {
            Debug.Log("Added weapon " + newWeap.weaponType.ToString());
            secondaryWeap = newWeap;
           
            UiManager.Instance.SetInteractableWeapon("secondary", true);

        }

        // setup for current weapon
        if (!currWeapon)
        {
            currWeapon = newWeap;
            Debug.Log("Current Weapon: " + currWeapon);
            ShowGun(newWeap);

            UiManager.Instance.UpdateCurrWeapAmmoUI(newWeap);
            UiManager.Instance.UpdateCurrAmmoStockUI(newWeap, pistolMag, rifleMag, shotgunMag);
            UiManager.Instance.SetFiringSystemButtons("fire");
        }
        else
        {
            Debug.Log("Current weapon occupied!");
        }
    }

    public void ShowGun(Weapon weap)
    {
        wGFX.sprite = weap.weaponSprite;
    }

    public void SwitchWeapon(string switchedWeapon)
    {
        if (switchedWeapon == "primary")
        {
            // switch to rifle/shotgun
            currWeapon = primaryWeap;
            ShowGun(currWeapon);

            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance. UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);

            
        }
        else if (switchedWeapon == "secondary")
        {
            // switch to pistol

            currWeapon = secondaryWeap;
            ShowGun(currWeapon);

            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance. UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);
        }
    }

#endregion

#region Weapon Functions 
// implementation currently for secondary weapon need to retweak this again
public void Shoot()
{
    currWeapon.GunShooting(this.wMuzzle);
}

public void Reload()
{
    if (currWeapon.weaponType == WeaponType.Pistol && pistolMag != 0)
    {
        StartCoroutine(GoWeaponReload(2f, currWeapon));
    }
    else if (currWeapon.weaponType == WeaponType.Rifle && rifleMag != 0)
    {
        StartCoroutine(GoWeaponReload(2f, currWeapon));
    }
    else if (currWeapon.weaponType == WeaponType.Shotgun && shotgunMag != 0)
    {
        StartCoroutine(GoWeaponReload(2f, currWeapon));
    }
    else
    {
        Debug.Log("No ammos in inventory!");
        // insert content to make this notify there isnt any left
    }
}

    #endregion

    #region Ammo Inventory Functions
    public void AddToAmmoInventory(Ammo ammoData)
    { 
        if (ammoData.ammoType == AmmoType.Pistol)
        {
            AddPistolMag(ammoData.GetAmmoCap());
            Debug.Log("Pistol Mag: " + pistolMag);
        }
        else if (ammoData.ammoType == AmmoType.Rifle)
        {
            AddRifleMag(ammoData.GetAmmoCap());
            Debug.Log("Rifle Mag: " + rifleMag);
        }
        else if (ammoData.ammoType == AmmoType.Shotgun)
        {
            AddShotgunMag(ammoData.GetAmmoCap());
            Debug.Log("Shotgun Mag: " + shotgunMag);
        }
    }


    #endregion

    #region Coroutines
    
    public IEnumerator GoWeaponReload(float reloadTime, Weapon equippedWeap)
    {

        UiManager.Instance.SetFiringSystemButtons("waitReload");


        if (equippedWeap.weaponType == WeaponType.Pistol)
        {
            ReducePistolMag(currWeapon.wMagCap);
            UiManager.Instance.UpdatePistolAmmoUi(this.pistolMag);
            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);
        }
        else if (equippedWeap.weaponType == WeaponType.Rifle)
        {
            ReduceRifleMag(currWeapon.wMagCap);
            UiManager.Instance.UpdateRifleAmmoUi(this.rifleMag);
            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);
        }
        else if (equippedWeap.weaponType == WeaponType.Shotgun)
        {
            ReduceShotgunMag(currWeapon.wMagCap);
            UiManager.Instance.UpdateShotgunAmmoUi(this.shotgunMag);
            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);
        }

        yield return new WaitForSeconds(reloadTime);
        
        currWeapon.wCurrAmmo += currWeapon.wMagCap;
        UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        UiManager.Instance.SetFiringSystemButtons("fire");
        
    }


    #endregion

}

