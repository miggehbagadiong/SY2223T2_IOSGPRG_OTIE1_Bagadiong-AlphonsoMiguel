using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void GunShooting(Transform muzzle)
    {
        Debug.Log("Shooting from " + this.weaponType);

        GameObject bullet = Instantiate(this.wBullet, muzzle.transform.position, muzzle.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzle.up * bullet.GetComponent<BulletComponent>().bulletData.bulletSpeed, ForceMode2D.Impulse);

        this.wCurrAmmo -= 1;
        UiManager.Instance.UpdateCurrWeapAmmoUI(this);
        Debug.Log("Current Ammo: " + this.wCurrAmmo);

        if (this.wCurrAmmo <= 0)
        {
            Debug.Log("No Ammo. Reload!");

            this.wCurrAmmo = 0;
            UiManager.Instance.SetFiringSystemButtons("reload");

        }

    }
}
