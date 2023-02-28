using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [Header("Weapon References")]
    public string weaponType;


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


}
