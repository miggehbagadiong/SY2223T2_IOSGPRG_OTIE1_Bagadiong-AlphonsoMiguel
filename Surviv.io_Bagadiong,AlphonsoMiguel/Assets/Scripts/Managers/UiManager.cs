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
    public GameObject fireButton;
    public GameObject reloadButton;


    #region Unity Functions

    private void Start()
    {
        // set the interactable to false on the very start
        primaryButton.GetComponent<Button>().interactable = false;
        secondaryButton.GetComponent<Button>().interactable = false;
        fireButton.GetComponent<Button>().interactable = false;
        reloadButton.GetComponent<Button>().interactable = false;

        // initialize the player health on start
        healthBar.SetMaxHealth(PlayerManager.Instance.GetPlayer().GetComponent<HealthComponent>().GetMaxHealth());

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

    public void UpdatePistolAmmoUi(int pistolMag)
    {
        pistolAmmoTxt.text = pistolMag.ToString();
    }

    public void UpdateRifleAmmoUi(int rifleMag)
    {
        rifleAmmoTxt.text = rifleMag.ToString();
    }

    public void UpdateShotgunAmmoUi(int shotgunMag)
    {
        shotgunAmmoTxt.text = shotgunMag.ToString();
    }

    public void UpdateAmmoUI(Ammo ammo, int ammoMag)
    {
        if (ammo.ammoType == AmmoType.Pistol)
            pistolAmmoTxt.text = ammoMag.ToString();
        else if (ammo.ammoType == AmmoType.Rifle)
            rifleAmmoTxt.text = ammoMag.ToString();
        else if (ammo.ammoType == AmmoType.Shotgun)
            shotgunAmmoTxt.text = ammoMag.ToString();
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
        if (currWeap.weaponType == WeaponType.Rifle)
        {
            primaryWeapTxt.text = currWeap.weaponType.ToString();

            currAmmoTxt.text = currWeap.wCurrAmmo.ToString();
            //currAmmoStockTxt.text = WeaponInventory.Instance.GetRifleMag().ToString();
        }
        else if (currWeap.weaponType == WeaponType.Shotgun)
        {
            primaryWeapTxt.text = currWeap.weaponType.ToString();

            currAmmoTxt.text = currWeap.wCurrAmmo.ToString();
            //currAmmoStockTxt.text = WeaponInventory.Instance.GetShotgunMag().ToString();
        }
        else if (currWeap.weaponType == WeaponType.Pistol) 
        {    
            secondaryWeapTxt.text = currWeap.weaponType.ToString();

            currAmmoTxt.text = currWeap.wCurrAmmo.ToString();
            //currAmmoStockTxt.text = WeaponInventory.Instance.GetPistolMag().ToString();
        }

    }

    public void UpdateCurrAmmoStockUI(Weapon currWeap, int pistolStock, int rifleStock, int shotgunStock)
    {
        if (currWeap.weaponType == WeaponType.Pistol)
        {
            currAmmoStockTxt.text = pistolStock.ToString();
        }
        else if (currWeap.weaponType == WeaponType.Rifle)
        {
            currAmmoStockTxt.text = rifleStock.ToString();
        }
        else if (currWeap.weaponType == WeaponType.Shotgun)
        {
            currAmmoStockTxt.text = shotgunStock.ToString();
        }
        
    }

    #endregion

    #region Buttons

    public void SetInteractableWeapon(string weaponButton, bool buttonState)
    {
        if (weaponButton == "primary") 
        {
            primaryButton.GetComponent<Button>().interactable = buttonState;
        }
        else if (weaponButton == "secondary")
        {
            secondaryButton.GetComponent<Button>().interactable = buttonState;
        }
    }

    public void SetFiringSystemButtons(string activeButton)
    {
        if (activeButton == "fire") // fire button is active
        {
            fireButton.GetComponent<Button>().interactable = true;
            reloadButton.GetComponent<Button>().interactable = false;
        }
        else if (activeButton == "reload") // reload button is active
        {
            fireButton.GetComponent<Button>().interactable = false;
            reloadButton.GetComponent<Button>().interactable = true;
        }
        else if (activeButton == "waitReload")
        {
            fireButton.GetComponent<Button>().interactable = false;
            reloadButton.GetComponent<Button>().interactable = false;
        }
    }

    #endregion



}
