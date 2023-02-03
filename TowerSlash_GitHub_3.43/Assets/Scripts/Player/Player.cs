using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void LateUpdate()
    {
        SwipeAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Game Over");
            
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

    private void SwipeAttack()
    {
        //Debug.Log("Can Attack");

        if (closestEnemy != null) 
        {
            if (SwipeController.Instance.swipeDir == closestEnemy.arrowDirection.ToString())
            {
                Destroy(closestEnemy.gameObject);
                //Debug.Log("Swipe correct! Enemy Destroyed!");
                // reference managers to this part

            }
            else if (SwipeController.Instance.swipeDir != closestEnemy.arrowDirection.ToString())
            {
                //Debug.Log("Swipe wrong. Player swipe disabled!");

                // start coroutine where swipe is disabled
            }
        }
        else
        {
            Debug.Log("No Enemy in Sight!");
        }
    }

}
