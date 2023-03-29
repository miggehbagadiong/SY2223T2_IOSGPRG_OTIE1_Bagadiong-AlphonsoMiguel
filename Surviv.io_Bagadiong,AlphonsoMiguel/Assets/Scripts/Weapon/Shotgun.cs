using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [Header("Shotgun Spread Component")]
    public float spread;
    

    public override void GunShooting(Transform muzzle)
    {
        Debug.Log("Shooting from " + this.weaponType);

        // spreading part
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(this.wBullet, muzzle.position, muzzle.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            Vector2 bulletDir = muzzle.transform.rotation * Vector2.up;
            Vector2 perpDir = Vector2.Perpendicular(bulletDir) * Random.Range(-spread, spread);
            bulletRb.velocity = (bulletDir + perpDir) * bullet.GetComponent<BulletComponent>().bulletData.bulletSpeed;

        }

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
