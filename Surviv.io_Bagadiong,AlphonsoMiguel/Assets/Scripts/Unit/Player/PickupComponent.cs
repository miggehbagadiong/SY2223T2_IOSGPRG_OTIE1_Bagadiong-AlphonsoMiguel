using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    private WeaponInventory pInventory;

    private void Start()
    {
        pInventory = PlayerManager.Instance.GetPlayerInventory();
    }

    private void OnTriggerEnter2D(Collider2D objectLoot)
    {
        if (objectLoot.gameObject.GetComponent<AmmoItem>())
        {
            Debug.Log("Collided with " +  objectLoot.gameObject);

            Destroy(objectLoot.gameObject);

            var ammoItem = objectLoot.gameObject.GetComponent<AmmoItem>();

            pInventory.AddToAmmoInventory(ammoItem.ammoData);
            UiManager.Instance.UpdateAmmoUI(ammoItem.ammoData, pInventory.GetAmmoMagData(ammoItem.ammoData));
        }

        else if (objectLoot.gameObject.GetComponent<WeaponItem>())
        {
            Debug.Log("Collided with " + objectLoot.gameObject);

            Destroy(objectLoot.gameObject);

            var weaponItem = objectLoot.gameObject.GetComponent<WeaponItem>();

            pInventory.AddWeaponToInventory(weaponItem.weaponData);
            UiManager.Instance.UpdateWeaponUI(weaponItem.weaponData);
           
            // add the other stuff here later

        }
    }

}
