using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    #region Player Variables

    [HideInInspector] public Enemy closestEnemy;

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        closestEnemy = FindClosestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
        }
    }

    public Enemy FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach(Enemy currEnemy in allEnemies)
        {
            float distanceToEnemy = (currEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy) 
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currEnemy;
            }
        }

        // Debug.Log(this.transform.position, closestEnemy);
         Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.red);

        return closestEnemy;
    }
}
