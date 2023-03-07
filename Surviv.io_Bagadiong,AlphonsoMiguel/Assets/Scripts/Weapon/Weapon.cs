using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType{
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3
};

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{

#region Variables

    [Header("Weapon Type")]
    public WeaponType weaponType;

    [Header("Weapon Ammo")]
    public int wCurrAmmo;
    public int wMaxAmmo;

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

}
