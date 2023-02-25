using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [HideInInspector] public Arrow eArrowComp;
    public ArrowDirection arrowDirection;
    public bool isArrowRightDir; // adjust this
    [HideInInspector] public string setArrowDir;

    [Header("Point")]
    public int point = 1;
    public float kill = 1f;

    [Header("Player Range")]
    public bool isInPlayerRange;
    public Vector2 rangePos;
    

    protected override void Start()
    {
        base.Start();

        this.isInPlayerRange = false;

        //rangePos = SpawnManager.Instance.GetVector2Range();
        rangePos = transform.GetChild(1).transform.position;
    }


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

    public ArrowDirection GetArrowDirection()
    {
        return arrowDirection;
    }

    public void CheckArrowDirection(int dirIndex)
    {
        if (this.gameObject == null)
        {
            if (dirIndex == 1)
                UiManager.Instance.rotArrowDirTxt.text = ArrowDirection.Up.ToString();
            else if (dirIndex == 2)
                UiManager.Instance.rotArrowDirTxt.text = ArrowDirection.Right.ToString();
            else if (dirIndex == 3)
                UiManager.Instance.rotArrowDirTxt.text = ArrowDirection.Down.ToString();
            else
                UiManager.Instance.rotArrowDirTxt.text = ArrowDirection.Left.ToString();
        }
        else
        {
            UiManager.Instance.rotArrowDirTxt.text = " ";
        }
       


        Debug.Log("Rotating Arrow Dir Index: " + dirIndex);
    }

    public void InitializeRotatingArrows(int index)
    {
        eArrowComp = transform.GetChild(0).gameObject.GetComponent<Arrow>();

        // insert the new parameter here
        if (PlayerManager.Instance.player.transform.position.y <= rangePos.y)
        {
            eArrowComp.isArrowRotating = true;
            
        }
        else
        {
            eArrowComp.isArrowRotating = false;
            //eArrowComp.SetFinalYellowArrowRender(index);
        }

    }
}
