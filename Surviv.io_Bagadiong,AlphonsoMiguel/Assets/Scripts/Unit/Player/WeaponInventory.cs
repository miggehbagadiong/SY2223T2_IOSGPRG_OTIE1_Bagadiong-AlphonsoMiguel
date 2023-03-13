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

    [HideInInspector] public List<Weapon> weaponsList = new List<Weapon>();
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

#region Weapon Instances

    public Transform GetMuzzle()
    {
        return wMuzzle;
    }

    public void AddWeapon(Weapon newWeap) // adds either primary or secondary weapon
    {
        //if (weapons[0] == null && (WeaponType.Rifle || WeaponType.Shotgun == null))
        //    return newWeap;
        if ((newWeap.weaponType.ToString() == WeaponType.Rifle.ToString() 
                || newWeap.weaponType.ToString() == WeaponType.Shotgun.ToString()) && !weaponsList[0])
        {
            weaponsList[0] = newWeap;
        }
        else if (newWeap.weaponType.ToString() == WeaponType.Pistol.ToString() && !weaponsList[1])
        {
            weaponsList[1] = newWeap;
        }
    }

    public Weapon AddCurrentWeapon(Weapon addCurrWeap)
    {
        currWeapon = addCurrWeap;
        return currWeapon;
    }

    public void ShowGun(Weapon weap)
    {
        wGFX.sprite = weap.weaponSprite;
        //wGFX.transform.Rotate(Vector3(0,0,90),transform.position);
    }

    public void CheckCurrentWeapon(Weapon setWeap)
    {
        
    }

#endregion

#region Weapon Functions 
// implementation currently for secondary weapon need to retweak this again
public void Shoot()
{
    if (!currWeapon)
    {
        GameObject bullet = Instantiate(currWeapon.wBullet, this.wMuzzle.transform.position, this.wMuzzle.transform.rotation);
        Rigidbody2D rb = weaponsList[1].wBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(this.wMuzzle.up * currWeapon.wBullet.GetComponent<BulletComponent>().bulletData.bulletSpeed, ForceMode2D.Impulse);

        if(currWeapon.wCurrAmmo > 0)
        {
            currWeapon.wCurrAmmo -= 1;
            UiManager.Instance.UpdateCurrWeapAmmoUI(currWeapon);
        }
        else
        {
            Debug.Log("No Ammo. Reload!");
            currWeapon.wCurrAmmo = 0;
        }
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
    public void AddToAmmoInventory(AmmoItem ammoPack)
    {
        if (ammoPack.ammoData.ammoType == AmmoType.Pistol)
            this.AddPistolMag(ammoPack.ammoData.ammoCount);
        else if (ammoPack.ammoData.ammoType == AmmoType.Rifle)
            this.AddRifleMag(ammoPack.ammoData.ammoCount);
        else if (ammoPack.ammoData.ammoType == AmmoType.Shotgun)
            this.AddShotgunMag(ammoPack.ammoData.ammoCount);
    }


    #endregion

}

