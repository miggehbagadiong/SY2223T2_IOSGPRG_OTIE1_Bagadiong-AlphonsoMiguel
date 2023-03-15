using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum WeaponType{
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3
};

[CreateAssetMenu(menuName = "Weapon/WeaponBase")]
[InitializeOnLoad]
public class Weapon : ScriptableObject
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
    public bool hasSpread;
    public bool isAutomatic;

    [Header("Bullet")]
    public GameObject wBullet;
    public float wBulletSpeed = 20f;    

#endregion

protected virtual void ResetParameters()
{
    wCurrAmmo = wMagCap;
}

#region Unity Functions
private void OnDisable() {
    ResetParameters();
}


#endregion

}
