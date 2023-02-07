using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationZone : Singleton<RotationZone>
{
    private bool isInRotationZone;

    private void Start()
    {
        isInRotationZone = true;    
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        this.isInRotationZone = true;
    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        this.isInRotationZone = false;
    //    }
    //}

    //public bool GetRotationZoneBool()
    //{
    //    return this.isInRotationZone;
    //}

}
