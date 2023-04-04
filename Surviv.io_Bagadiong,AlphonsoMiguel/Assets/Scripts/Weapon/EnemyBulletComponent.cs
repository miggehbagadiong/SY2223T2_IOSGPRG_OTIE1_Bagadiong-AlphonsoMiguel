using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletComponent : MonoBehaviour
{
    public Bullet eBulletData;

    // initialize for player only
    void OnTriggerEnter2D(Collider2D unitObj)
    {
        if (unitObj.gameObject.GetComponent<Player>())
        {
            Debug.Log("Player taking damage!");
            unitObj.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().TakeDamage((int)eBulletData.bulletDMG);
            UiManager.Instance.SetHealth(unitObj.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().GetHealth());
            Destroy(this.gameObject);

            if (unitObj.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().GetHealth() <= 0)
            {
                Debug.Log("Player Dead!");
                EventManager.Instance.InvokePlayerDeath();
            }
        }
        else if (unitObj.gameObject.GetComponent<WorldObjects>() || unitObj.gameObject.GetComponent<WorldWalls>())
        {
            Destroy(this.gameObject);
            Debug.Log("Hit Obstacles!");
        }
    }
}
