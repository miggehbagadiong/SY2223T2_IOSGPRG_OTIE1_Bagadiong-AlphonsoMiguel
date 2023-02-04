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

    public ArrowDirection SetArrowDirection(int dirIndex)
    {
        if (dirIndex == 1)
           arrowDirection = ArrowDirection.Up;
        else if (dirIndex == 2)
           arrowDirection = ArrowDirection.Right;
        else if (dirIndex == 3)
            arrowDirection = ArrowDirection.Down;
        else
            arrowDirection = ArrowDirection.Left;

        return arrowDirection;
    }

    
}
