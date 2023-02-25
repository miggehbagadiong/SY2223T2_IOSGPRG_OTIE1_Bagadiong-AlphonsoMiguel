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
    List<Enemy> enemyList;

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
            //Destroy(collision.gameObject);

            //enemyList.Add(collision.gameObject.GetComponent<Enemy>());
            //SwipeAttack(); //allow to do swipe attacks

        }
    }

   

    private void SwipeAttack()
    {
        // set parameters to the swipe zone
        closestEnemy = SpawnManager.Instance.enemies[0];
        //closestEnemy = enemyList[0];

        //if (SpawnManager.Instance.enemies != null) 
        if (closestEnemy != null)
        {
            if (SwipeController.Instance.swipeDir == closestEnemy.arrowDirection.ToString())
            {
                Destroy(closestEnemy.gameObject);
                SpawnManager.Instance.enemies.Remove(closestEnemy);
                enemyList.Remove(closestEnemy);

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

                //Destroy(closestEnemy.gameObject);
                SpawnManager.Instance.enemies.Remove(closestEnemy);
                enemyList.Remove(closestEnemy);
                
                this.unitHealth.TakeDamage(1);
                UiManager.Instance.lifePointTxt.text = this.unitHealth.GetLifePoint().ToString();

                if (this.unitHealth.lifePoint <= 0)
                {
                    GameManager.Instance.GoToGameOverScreen();
                }

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

    private IEnumerator DisplaySwipeDisabledText()
    {

        if (this.isSwipeEnabled == false)
        {
            UiManager.Instance.swipeDisabledTxt.text = "Swipe Disabled!";

            yield return new WaitForSeconds(0.5f);

            UiManager.Instance.swipeDisabledTxt.text = " ";
        }
        else
        {
            this.isSwipeEnabled = true;
        }

    }

}
