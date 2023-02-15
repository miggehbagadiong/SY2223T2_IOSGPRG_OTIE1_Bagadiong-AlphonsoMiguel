using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Player : Unit
{
    #region Player Variables

    [HideInInspector] public Enemy closestEnemy;
    [HideInInspector] public bool isSwipeEnabled = true;

    [HideInInspector] public int killMultiplier;
    [HideInInspector] public int killDelay;

    public SpriteRenderer playerSprite;

    #endregion

    protected override void Start()
    {
        base.Start();

        // player health
        unitHealth = GetComponent<HealthComponent>();
        UiManager.Instance.lifePointTxt.text = this.unitHealth.GetLifePoint().ToString();

        //player sprite
        playerSprite = GetComponent<SpriteRenderer>();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        SwipeAttack();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            SpawnManager.Instance.enemies.Remove(collision.GetComponent<Enemy>());  
            this.unitHealth.TakeDamage(1);
            this.isSwipeEnabled = true;

            UiManager.Instance.lifePointTxt.text = this.unitHealth.GetLifePoint().ToString();

            if (this.unitHealth.lifePoint <= 0)
            {
                GameManager.Instance.GoToGameOverScreen();
            }

        }
    }

   

    private void SwipeAttack()
    {
        // set parameters to the swipe zone

        if (SpawnManager.Instance.enemies != null) 
        {
            closestEnemy = SpawnManager.Instance.enemies[0];    

            if (SwipeController.Instance.swipeDir == closestEnemy.arrowDirection.ToString())
            {
                Destroy(closestEnemy.gameObject);
                SpawnManager.Instance.enemies.RemoveAt(0);
                
                // reference managers to this part
                ScoreManager.Instance.AddScore(closestEnemy.point);
                ScoreManager.Instance.AddKills(closestEnemy.kill);

                Powerup.Instance.PowerupAfterKill(this);
                ProgressBar.Instance.AddBar(ScoreManager.Instance.killScore, 0.05f);
                UiManager.Instance.lifePointTxt.text = this.unitHealth.GetLifePoint().ToString();

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

    public void SetPlayerParameters(int setLifePoints, int setKillMultiplier, Sprite setSprite)
    {
        this.unitHealth.lifePoint = setLifePoints;
        this.killMultiplier = setKillMultiplier;
        this.playerSprite.sprite = setSprite;
    }

}
