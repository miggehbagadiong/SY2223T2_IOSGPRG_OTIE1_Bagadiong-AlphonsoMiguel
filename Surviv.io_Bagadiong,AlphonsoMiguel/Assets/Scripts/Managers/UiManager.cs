using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    // variable parameters
    [Header("Health Bar Parameters")]
    public Slider slider;
    public HealthBar healthBar;

    [Header("Ammo Value Parameters")]
    public TextMeshProUGUI pistolAmmoTxt;
    public TextMeshProUGUI rifleAmmoTxt;
    public TextMeshProUGUI shotgunAmmoTxt;

    [Header("Weapon Parameters")]
    public TextMeshProUGUI primaryWeapTxt;
    public TextMeshProUGUI secondaryWeapTxt;

#region Player Health

public void SetMaxHealth(int refHealth)
{
    slider.maxValue = refHealth;
    slider.value = refHealth;
}

public void SetHealth(int refHealth)
{
    slider.value = refHealth;
}

#endregion

#region Player Ammo and Weapon

public void UpdateAmmoUI(Ammo ammo)
{
    if (ammo.ammoType == AmmoType.Pistol)
        pistolAmmoTxt.text = ammo.ammoCount.ToString();
    else if (ammo.ammoType == AmmoType.Rifle)
        rifleAmmoTxt.text = ammo.ammoCount.ToString();
    else if (ammo.ammoType == AmmoType.Shotgun)
        shotgunAmmoTxt.text = ammo.ammoCount.ToString();
}

public void UpdateWeaponUI(Weapon weapon)
{
    if (weapon.weaponType == WeaponType.Rifle || weapon.weaponType == WeaponType.Shotgun)
    {
        primaryWeapTxt.text = weapon.weaponType.ToString();
    }
    else if (weapon.weaponType == WeaponType.Pistol)
    {
        secondaryWeapTxt.text = weapon.weaponType.ToString();
    }
}

#endregion

}
