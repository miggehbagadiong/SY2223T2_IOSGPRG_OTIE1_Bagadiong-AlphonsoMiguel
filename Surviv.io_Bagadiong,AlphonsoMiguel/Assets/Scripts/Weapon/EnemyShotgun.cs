using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : Weapon
{
    [Header("Shotgun Spread Component")]
    public float eSpread;
    
    public override void GunShooting(Transform muzzle)
    {
        Debug.Log("Shooting from " + this.weaponType);

        // spreading part
        for (int i = 0; i < 8; i++)
        {
            GameObject eBullet = Instantiate(this.wBullet, muzzle.position, muzzle.rotation);
            Rigidbody2D bulletRb = eBullet.GetComponent<Rigidbody2D>();
            Vector2 bulletDir = muzzle.transform.rotation * Vector2.up;
            Vector2 perpDir = Vector2.Perpendicular(bulletDir) * Random.Range(-eSpread, eSpread);
            bulletRb.velocity = (bulletDir + perpDir) * eBullet.GetComponent<BulletComponent>().bulletData.bulletSpeed;

        }

        this.wCurrAmmo -= 1;

        if (this.wCurrAmmo <= 0)
        {
            this.wCurrAmmo = 0;

        }
    }
}
