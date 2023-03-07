using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public Bullet bulletData;

    private void OnTriggerEnter2D(Collider2D unitObject) 
    {
        if (unitObject.gameObject.GetComponent<Player>())
        {
            unitObject.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().TakeDamage((int)bulletData.bulletDMG);
            Debug.Log("Damaged Player!");
        }
    }

}
