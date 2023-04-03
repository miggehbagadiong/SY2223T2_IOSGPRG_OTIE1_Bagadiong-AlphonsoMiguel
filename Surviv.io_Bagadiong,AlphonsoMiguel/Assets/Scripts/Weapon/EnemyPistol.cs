using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPistol : Weapon
{
    public override void GunShooting(Transform muzzle)
    {
        Debug.Log("Shooting from " + this.weaponType);

        GameObject bullet = Instantiate(this.wBullet, muzzle.transform.position, muzzle.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzle.up * bullet.GetComponent<BulletComponent>().bulletData.bulletSpeed, ForceMode2D.Impulse);

        this.wCurrAmmo -= 1;

        if (this.wCurrAmmo <= 0)
        {
            this.wCurrAmmo = 0;
        }

    }
}
