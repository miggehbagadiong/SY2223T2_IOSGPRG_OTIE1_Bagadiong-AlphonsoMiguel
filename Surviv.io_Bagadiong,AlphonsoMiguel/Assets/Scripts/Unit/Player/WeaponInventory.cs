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
    [HideInInspector] Weapon primaryWeap;
    [HideInInspector] Weapon secondaryWeap;
    [HideInInspector] public Weapon currWeapon;
    [HideInInspector] public bool hasNoAmmo = false;
    private float currTimer = 0;


   // [Header("Ammo References")]
    [HideInInspector] public int rifleMag;
    [HideInInspector] public int pistolMag;
    [HideInInspector] public int shotgunMag;

    [HideInInspector] int refData;

    private void Update()
    {
        // fireRate implementation
        currTimer += 1 * Time.deltaTime;

        // constant update for the ammo stock due to instances when just inserted only still nothing happens
        if (currWeapon)
            UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);

    }

#region Ammo References

    private void AddPistolMag(int add)
    {
        pistolMag += add;
    }

    private void AddRifleMag(int add)
    {
        rifleMag += add;
    }

    private void AddShotgunMag(int add)
    {
        shotgunMag += add;
    }

    private void ReducePistolMag(int reduce)
    {
        pistolMag -= reduce;
    }

    private void ReduceRifleMag(int reduce)
    {
        rifleMag -= reduce;
    }

    private void ReduceShotgunMag(int reduce)
    {
        shotgunMag -= reduce;
    }

    private void CheckPistolCount(Ammo ammoRef)
    {
        if (pistolMag >= ammoRef.maxAmmoCap)
        {
            pistolMag = ammoRef.maxAmmoCap;
        }
    }

    private void CheckRifleCount(Ammo ammoRef)
    {
        if (rifleMag >= ammoRef.maxAmmoCap)
        {
            rifleMag = ammoRef.maxAmmoCap;
        }    
    }

    private void CheckShotgunCount(Ammo ammoRef)
    {
        if (shotgunMag >= ammoRef.maxAmmoCap)
        {
            shotgunMag = ammoRef.maxAmmoCap;
        }
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

    //if (currTimer >= currWeapon.wFireRate && GameManager.Instance.GetIsFireButtonHeld())
    if (currTimer >= currWeapon.wFireRate)
    {
        currWeapon.GunShooting(this.wMuzzle);
        currTimer = 0;
    }
}

public void Reload()
{
    // will do the reload here
    StartCoroutine(GoWeaponReload(2f, currWeapon));

}

    #endregion

    #region Ammo Inventory Functions
    public void AddToAmmoInventory(Ammo ammoData)
    { 
        if (ammoData.ammoType == AmmoType.Pistol)
        {
            AddPistolMag(ammoData.GetAmmoCount());
            CheckPistolCount(ammoData);

            Debug.Log("Pistol Mag: " + pistolMag);
        }
        else if (ammoData.ammoType == AmmoType.Rifle)
        {
            AddRifleMag(ammoData.GetAmmoCount());
            CheckRifleCount(ammoData);

            Debug.Log("Rifle Mag: " + rifleMag);
        }
        else if (ammoData.ammoType == AmmoType.Shotgun)
        {
            AddShotgunMag(ammoData.GetAmmoCount());
            CheckShotgunCount(ammoData);

            Debug.Log("Shotgun Mag: " + shotgunMag);
        }
    }
    #endregion

    #region Coroutines
    
    private IEnumerator GoWeaponReload(float reloadTime, Weapon equippedWeap)
    {
        UiManager.Instance.SetFiringSystemButtons("waitReload");

        if (equippedWeap.weaponType == WeaponType.Pistol && this.pistolMag > 0)
        {
            ReducePistolMag(currWeapon.wMagCap);
            UiManager.Instance.UpdatePistolAmmoUi(this.pistolMag);
            hasNoAmmo = false;
        }
        else if (equippedWeap.weaponType == WeaponType.Rifle && this.rifleMag > 0)
        {
            ReduceRifleMag(currWeapon.wMagCap);
            UiManager.Instance.UpdateRifleAmmoUi(this.rifleMag);
            hasNoAmmo = false;
        }
        else if (equippedWeap.weaponType == WeaponType.Shotgun && this.shotgunMag > 0)
        {
            ReduceShotgunMag(currWeapon.wMagCap);
            UiManager.Instance.UpdateShotgunAmmoUi(this.shotgunMag);
            hasNoAmmo = false;
        }
        else{
            Debug.Log("Out of Ammo!");
            hasNoAmmo = true;
            UiManager.Instance.SetFiringSystemButtons("reload");
        }

        UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        UiManager.Instance.UpdateCurrAmmoStockUI(currWeapon, pistolMag, rifleMag, shotgunMag);

        yield return new WaitForSeconds(reloadTime);
        
        if (hasNoAmmo != true)
        {
            currWeapon.wCurrAmmo += currWeapon.wMagCap; // fix this
            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
            UiManager.Instance.SetFiringSystemButtons("fire");
        }
        
        
    }


    #endregion

}
