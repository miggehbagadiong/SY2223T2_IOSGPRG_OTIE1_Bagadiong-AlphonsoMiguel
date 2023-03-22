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
        else if (unitObject.gameObject.GetComponent<Enemy>())
        {
            unitObject.gameObject.GetComponent<Enemy>().GetComponent<HealthComponent>().TakeDamage((int)bulletData.bulletDMG);
            Debug.Log("Damaged Enemy");
        }
        else if (unitObject.gameObject.GetComponent<WorldObjects>() || unitObject.gameObject.GetComponent<WorldWalls>())
        {
            Destroy(this.gameObject);
            Debug.Log("Hit Obstacles");
        }
    }

}
