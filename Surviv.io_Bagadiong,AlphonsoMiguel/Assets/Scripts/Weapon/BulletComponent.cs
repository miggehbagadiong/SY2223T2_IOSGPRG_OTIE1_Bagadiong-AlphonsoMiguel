using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public Bullet bulletData;
    
    // initialize for player only
    private void OnTriggerEnter2D(Collider2D unitObject) 
    {
        if (unitObject.gameObject.GetComponent<Player>())
        {
            unitObject.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().TakeDamage((int)bulletData.bulletDMG);
            UiManager.Instance.SetHealth(unitObject.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().GetHealth());
            Destroy(this.gameObject);
            Debug.Log("Damaged Player!");

            if (unitObject.gameObject.GetComponent<Player>().GetComponent<HealthComponent>().GetHealth() <= 0)
            {
                Debug.Log("Player Dead!");
                EventManager.Instance.InvokePlayerDeath();
            }

        }
        else if (unitObject.gameObject.GetComponent<Enemy>())
        {
            unitObject.gameObject.GetComponent<Enemy>().GetComponent<HealthComponent>().TakeDamage((int)bulletData.bulletDMG);
            Destroy(this.gameObject);
            Debug.Log("Damaged Enemy");

            if (unitObject.gameObject.GetComponent<Enemy>().GetComponent<HealthComponent>().currHealth <= 0)
            {
                // when the unit dies invoke death
                EventManager.Instance.InvokeEnemyDeath(); // slight bug on shotgun
                Destroy(unitObject.gameObject);
                Debug.Log("Enemy Killed!");
            }
        }
        else if (unitObject.gameObject.GetComponent<WorldObjects>() || unitObject.gameObject.GetComponent<WorldWalls>())
        {
            Destroy(this.gameObject);
            Debug.Log("Hit Obstacles");
        }
    }

}
