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
    [HideInInspector] public int pistolMagCap;
    [HideInInspector] public int rifleMagCap;
    [HideInInspector] public int shotgunMagCap;

    private void Start()
    {
        
    }   

#region Ammo References

    public int AddPistolMag(int add)
    {
        pistolMag += add;

        return pistolMag;
    }

    public int AddRifleMag(int add)
    {
        rifleMag += add;

        return rifleMag;
    }

    public int AddShotgunMag(int add)
    {
        shotgunMag += add;

        return shotgunMag;
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
      
        if ((newWeap.weaponType == WeaponType.Rifle 
                || newWeap.weaponType == WeaponType.Shotgun) && !primaryWeap)
        {
            Debug.Log("Added weapon " + newWeap.weaponType.ToString());
            primaryWeap = newWeap;
            UiManager.Instance.SetInteractableWeapon(1, true); // sets the UiButton to True

        }
        else if ((newWeap.weaponType == WeaponType.Pistol) && !secondaryWeap)
        {
            Debug.Log("Added weapon " + newWeap.weaponType.ToString());
            secondaryWeap = newWeap;
            UiManager.Instance.SetInteractableWeapon(2, true);

        }

        if (!currWeapon)
        {
            currWeapon = newWeap;
            Debug.Log("Current Weapon: " + currWeapon);
            ShowGun(newWeap);
            UiManager.Instance.UpdateCurrWeapAmmoUI(newWeap);
            UiManager.Instance.SetFiringSystemButtons("fire");
        }
    }

    public void ShowGun(Weapon weap)
    {
        wGFX.sprite = weap.weaponSprite;
        //wGFX.transform.Rotate(Vector3(0,0,90),transform.position);
    }

    public void SwitchWeapon(Weapon currWeap)
    {

    }

#endregion

#region Weapon Functions 
// implementation currently for secondary weapon need to retweak this again
public void Shoot()
{
    if (currWeapon)
    {
        // reimplement for the shotgun
        GameObject bullet = Instantiate(currWeapon.wBullet, this.wMuzzle.transform.position, this.wMuzzle.transform.rotation);
        //Rigidbody2D rb = currWeapon.wBullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(this.wMuzzle.up * bullet.GetComponent<BulletComponent>().bulletData.bulletSpeed, ForceMode2D.Impulse);

        currWeapon.wCurrAmmo -= 1;
        UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        Debug.Log("Current Ammo: " + currWeapon.wCurrAmmo);

        if (currWeapon.wCurrAmmo <= 0)
        {
            Debug.Log("No Ammo. Reload!");
            currWeapon.wCurrAmmo = 0;
            UiManager.Instance.SetFiringSystemButtons("reload");
        }

        // if (currWeapon.wCurrAmmo != 0)
        // {
        //     // currWeapon.wCurrAmmo -= 1;
        //     // UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        //     // Debug.Log("Current Ammo: " + currWeapon.wCurrAmmo);
            
        // }
        // else
        // {
        //     Debug.Log("No Ammo. Reload!");
        //     currWeapon.wCurrAmmo = 0;
        //     UiManager.Instance.SetFiringSystemButtons("reload");
        // }
    }
    else
    {
        Debug.Log("Is null. recheck!");
        return;
    }

}

public void Reload()
{
    if (currWeapon.wCurrAmmo <= 0 || currWeapon.wCurrAmmo >= 0)
    {
        Debug.Log("Reloading!");

        int magBag = GetPistolMag();
        magBag -= currWeapon.wMagCap;
        UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        
    }
}

    #endregion

    #region Ammo Inventory Functions
    public void AddToAmmoInventory(Ammo ammoData)
    { 
        if (ammoData.ammoType == AmmoType.Pistol)
            AddPistolMag(ammoData.GetAmmoCap());
        else if (ammoData.ammoType == AmmoType.Rifle)
            AddRifleMag(ammoData.GetAmmoCap());
        else if (ammoData.ammoType == AmmoType.Shotgun)
            AddShotgunMag(ammoData.GetAmmoCap());
    }


    #endregion

    #region Coroutines
    
    public IEnumerator GoWeaponReload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);

        int magBag = GetPistolMag();
        magBag -= currWeapon.wMagCap;
        UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
    }


    #endregion

}

