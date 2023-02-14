using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeZone : Singleton<SwipeZone>
{
    [SerializeField] bool canSwipe;
    List<Enemy> enemyList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyList.Add(collision.gameObject.GetComponent<Enemy>());  
            this.canSwipe = true;
            Debug.Log("enemy in swipe zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject.GetComponent<Enemy>());
            this.canSwipe = false;
            Debug.Log("enemy not in swipe zone");
        }
    }

    public bool GetCanSwipe()
    {
        return this.canSwipe;
    }
}
