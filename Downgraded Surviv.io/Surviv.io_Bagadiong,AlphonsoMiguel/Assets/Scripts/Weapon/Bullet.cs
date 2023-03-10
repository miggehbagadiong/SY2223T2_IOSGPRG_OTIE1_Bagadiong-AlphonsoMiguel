using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet")]
public class Bullet : ScriptableObject
{    
    public WeaponType weaponType;
    public float bulletDMG;
    public float bulletSpeed;


}
