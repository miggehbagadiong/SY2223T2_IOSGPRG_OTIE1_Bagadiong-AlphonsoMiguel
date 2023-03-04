using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private WeaponInventory pInventory;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.uHealthComponent = GetComponent<HealthComponent>();
        pInventory = GetComponent<WeaponInventory>();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

    private void OnTriggerEnter2D(Collider2D objectLoot) 
    {
        // player looting system

        if (objectLoot.gameObject.GetComponent<AmmoItem>())
        {
            if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Pistol)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);

                pInventory.AddPistolMag(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoCount);
                UiManager.Instance.UpdateAmmoUI(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData);

            }
            else if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Shotgun)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);

                pInventory.AddShotgunMag(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoCount);
                UiManager.Instance.UpdateAmmoUI(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData);
            }
            else if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Rifle)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);

                pInventory.AddRifleMag(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoCount);
                UiManager.Instance.UpdateAmmoUI(objectLoot.gameObject.GetComponent<AmmoItem>().ammoData);
            }


        }
        else if (objectLoot.gameObject.GetComponent<WeaponItem>()) // reimplement this due to primary and secondary method implementation
        {
            if (objectLoot.gameObject.GetComponent<WeaponItem>().weaponData.weaponType == WeaponType.Pistol)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);
                
                // insert here the rest

            }
            else if (objectLoot.gameObject.GetComponent<WeaponItem>().weaponData.weaponType == WeaponType.Shotgun)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);

                // insert here the rest

            }
            else if (objectLoot.gameObject.GetComponent<WeaponItem>().weaponData.weaponType == WeaponType.Rifle)
            {
                Debug.Log("Collided with " + objectLoot.gameObject);
                Destroy(objectLoot.gameObject);

                // insert here the rest

                
            }

        }
    }

}
