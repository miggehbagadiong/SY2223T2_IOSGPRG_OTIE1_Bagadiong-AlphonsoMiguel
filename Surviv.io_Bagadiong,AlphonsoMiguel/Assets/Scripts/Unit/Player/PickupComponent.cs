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
            pInventory.AddToAmmoInventory(objectLoot.gameObject.GetComponent<AmmoItem>());
            UiManager.Instance.UpdateAmmoUI(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData); // maybe place this here instead since it was simplified
        }

        else if (objectLoot.gameObject.GetComponent<WeaponItem>())
        {

        }
    }
}
