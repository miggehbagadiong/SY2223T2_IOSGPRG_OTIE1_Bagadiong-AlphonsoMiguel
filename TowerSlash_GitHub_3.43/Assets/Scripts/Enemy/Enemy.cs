using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    //public Arrow enemyArrow;
    public ArrowDirection arrowDirection;
    public bool isArrowRightDir; // adjust this
    [HideInInspector] public string setArrowDir;

    void Start()
    {
        //enemyArrow= GetComponent<Arrow>();
        Arrow.Instance.SetArrowRender((int)arrowDirection, isArrowRightDir);
    }

    void Update()
    {
        
    }

    void SetArrowDirection()
    {

    }

    
}
