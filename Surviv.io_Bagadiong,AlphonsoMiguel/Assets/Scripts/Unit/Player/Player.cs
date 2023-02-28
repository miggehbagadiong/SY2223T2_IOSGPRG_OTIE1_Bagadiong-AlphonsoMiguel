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
        if (objectLoot.gameObject.GetComponent<AmmoItem>())
        {
            if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Pistol)
            {
                // parameters here
            }
            else if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Shotgun)
            {

            }
            else if (objectLoot.gameObject.GetComponent<AmmoItem>().ammoData.ammoType == AmmoType.Rifle)
            {

            }


        }
    }

}
