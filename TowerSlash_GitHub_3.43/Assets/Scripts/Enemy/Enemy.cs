using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [HideInInspector] public Arrow eArrowComp;
    public ArrowDirection arrowDirection;
    public bool isArrowRightDir; // adjust this
    [HideInInspector] public string setArrowDir;
    [HideInInspector] public int arrowPicker; // pick either red/green or yellow

    void Start()
    {
        eArrowComp = transform.GetChild(0).gameObject.GetComponent<Arrow>();
        eArrowComp.SetArrowRender((int)arrowDirection, isArrowRightDir);
        //eArrowComp.SetRotatingArrowRender();
    }

    void Update()
    {
        
    }

    void SetArrowDirection()
    {

    }

    
}
