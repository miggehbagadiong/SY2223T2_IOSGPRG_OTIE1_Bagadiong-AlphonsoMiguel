using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType{
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3
};

[CreateAssetMenu(menuName ="AmmoData")]
public class Ammo : ScriptableObject
{
    public AmmoType ammoType;
    public float ammoDmg;
    public int ammoCount;
    public int maxAmmoCap;

    public int SetAmmoAmount(int aAmount)
    {
        ammoCount = aAmount;

        return aAmount;
    }

    public int SetMaxAmmoAmount(int aMaxAmount)
    {
        maxAmmoCap = aMaxAmount;

        return aMaxAmount;
    }

    public float GetAmmoDamage()
    {
        return ammoDmg;
    }

    public int GetAmmoCap()
    {
        return maxAmmoCap;
    }
    
}
