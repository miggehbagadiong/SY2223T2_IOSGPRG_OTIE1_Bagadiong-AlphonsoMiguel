using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Player : Unit
{
    #region Player Variables

    [HideInInspector] public Enemy closestEnemy;
    [HideInInspector] public bool isSwipeEnabled = true;

    #endregion

    protected override void Start()
    {
        base.Start();

        unitHealth = GetComponent<HealthComponent>();
    }

    protected override void Update()
    {
        base.Update();

        closestEnemy = FindClosestEnemy();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        SwipeAttack();
        
    }

    protected override void CheckHealth()
    {
        base.CheckHealth();

        UiManager.Instance.lifePointTxt.text = this.unitHealth.GetLifePoint().ToString();

        if (this.unitHealth.lifePoint <= 0)
        {
            GameManager.Instance.GoToGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            this.unitHealth.TakeDamage(1);
            this.isSwipeEnabled = true;
            
        }
    }

    //reimplement this
    public Enemy FindClosestEnemy() // change this since inefficient
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
        // set parameters to the swipe zone

        if (closestEnemy != null) 
        {
            if (SwipeController.Instance.swipeDir == closestEnemy.arrowDirection.ToString())
            {
                Destroy(closestEnemy.gameObject);
                //Debug.Log("Swipe correct! Enemy Destroyed!");
                // reference managers to this part
                ScoreManager.Instance.AddScore(closestEnemy.point);
                ScoreManager.Instance.AddKills(closestEnemy.kill);

            }
            else if (SwipeController.Instance.swipeDir != closestEnemy.arrowDirection.ToString())
            {
                Debug.Log("Swipe wrong. Player swipe disabled!");
                this.isSwipeEnabled = false;

                // start coroutine where swipe is disabled
            }
        }
        else
        {
            Debug.Log("No Enemy in Sight!");
        }
    }

}
