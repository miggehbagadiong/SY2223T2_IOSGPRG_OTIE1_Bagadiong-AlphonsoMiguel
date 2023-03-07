using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    // Weapon References
    [Header("Weapon References")]
    [SerializeField] GameObject wHeld; // means "Weapon Held"
    [SerializeField] Transform wMuzzle;
    [SerializeField] SpriteRenderer wGFX;

    [HideInInspector] public List<Weapon> weapons = new List<Weapon>();
    [HideInInspector] public Weapon currWeapon;


    [Header("Ammo References")]
    public int rifleMag;
    public int pistolMag;
    public int shotgunMag;



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
                || newWeap.weaponType.ToString() == WeaponType.Shotgun.ToString()) && !weapons[0])
        {
            weapons[0] = newWeap;
        }
        else if (newWeap.weaponType.ToString() == WeaponType.Pistol.ToString() && !weapons[1])
        {
            weapons[1] = newWeap;
        }
    }

    public void ShowGun(Weapon weap)
    {
        wGFX.sprite = weap.weaponSprite;
        //wGFX.transform.Rotate(Vector3(0,0,90),transform.position);
    }

#endregion

#region Weapon Functions 
// implementation currently for secondary weapon need to retweak this again
public void Shoot()
{
    GameObject bullet = Instantiate(weapons[1].wBullet, this.wMuzzle.transform.position, this.wMuzzle.transform.rotation);
    Rigidbody2D rb = weapons[1].wBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(this.wMuzzle.up * weapons[1].wBullet.GetComponent<BulletComponent>().bulletData.bulletSpeed, ForceMode2D.Impulse);

    if(weapons[1].wCurrAmmo > 0)
    {
        weapons[1].wCurrAmmo -= 1;
        
    }

}

public void Reload()
{
    if (weapons[1].wCurrAmmo <= 0 || weapons[1].wCurrAmmo >= 0)
    {

    }
}

#endregion


}
