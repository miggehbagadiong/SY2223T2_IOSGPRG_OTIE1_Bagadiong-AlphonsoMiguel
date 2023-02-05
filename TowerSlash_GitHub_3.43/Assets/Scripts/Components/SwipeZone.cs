using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeZone : Singleton<SwipeZone>
{
    [HideInInspector] public bool canSwipe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.canSwipe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.canSwipe = false;
        }
    }
}
