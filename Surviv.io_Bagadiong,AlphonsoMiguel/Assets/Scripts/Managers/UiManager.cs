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

    [Header("Current Weapon Ammo Parameters")]
    public TextMeshProUGUI currAmmoTxt;
    public TextMeshProUGUI currAmmoStockTxt;

    [Header("Button Components")]
    public GameObject primaryButton;
    public GameObject secondaryButton;


    #region Unity Functions

    private void Start()
    {
        primaryButton.GetComponent<Button>().interactable = false;
        secondaryButton.GetComponent<Button>().interactable = false;
    }

    #endregion


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

    public void UpdateCurrWeapAmmoUI(Weapon currWeap)
    {
        currAmmoTxt.text = currWeap.wCurrAmmo.ToString();
        currAmmoStockTxt.text = currWeap.wMagCap.ToString();
    
        if (currWeap.weaponType == WeaponType.Rifle || currWeap.weaponType == WeaponType.Shotgun)
        {
            primaryWeapTxt.text = currWeap.weaponType.ToString();
        }
        else if (currWeap.weaponType == WeaponType.Pistol) 
        {    
            secondaryWeapTxt.text = currWeap.weaponType.ToString();
        }

    }

    #endregion

    #region Buttons

    public void SetInteractableWeapon(int buttonIndex, bool buttonState)
    {
        if (buttonIndex == 1) 
        {
            primaryButton.GetComponent<Button>().interactable = buttonState;
        }
        else if (buttonIndex == 2)
        {
            secondaryButton.GetComponent<Button>().interactable = buttonState;
        }
    }

    #endregion



}
