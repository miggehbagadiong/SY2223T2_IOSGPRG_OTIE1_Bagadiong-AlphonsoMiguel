using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum WeaponType{
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3
};

public class Weapon : MonoBehaviour
{

#region Variables

    [Header("Weapon Type")]
    public WeaponType weaponType;

    [Header("Weapon Ammo")]
    public int wCurrAmmo;
    public int wMaxAmmo;
    public int wMagCap;

    [Header("Weapon Render")]
    public Sprite weaponSprite;

    [Header("Weapon Firing")]
    public float wFireRate;

    [Header("Bullet")]
    public GameObject wBullet;
    public float wBulletSpeed = 20f;    

#endregion

// shooting events will be run through the weapon since
// there is an instance like the shotgun to have a spread
public virtual void GunShooting(Transform muzzle)
{
    
}

protected virtual void ResetParameters()
{
    wCurrAmmo = wMagCap;
}

#region Unity Functions
protected virtual void OnDisable() {
    ResetParameters();
}


#endregion

}
