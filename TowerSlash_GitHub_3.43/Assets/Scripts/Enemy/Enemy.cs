using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Arrow eArrowComp;
    public ArrowDirection arrowDirection;
    public bool isArrowRightDir; // adjust this
    [HideInInspector] public string setArrowDir;

    void Start()
    {
        eArrowComp = transform.GetChild(0).gameObject.GetComponent<Arrow>();
        eArrowComp.SetArrowRender((int)arrowDirection, isArrowRightDir);
    }

    void Update()
    {
        
    }

    void SetArrowDirection()
    {

    }

    
}
