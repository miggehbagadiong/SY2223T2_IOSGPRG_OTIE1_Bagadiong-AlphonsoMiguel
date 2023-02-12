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

    // rotating arrow
    public bool isInPlayerRange;

    protected override void Start()
    {
        base.Start();

        this.isInPlayerRange = false;
        
    }

    protected override void CheckHealth()
    {
        base.CheckHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SwipeZone"))
        {
            this.isInPlayerRange = true;
            eArrowComp = transform.GetChild(0).gameObject.GetComponent<Arrow>();
            eArrowComp.SetArrowRotatingBool(this.isInPlayerRange);

            Debug.Log("enemy in swipe zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SwipeZone"))
        {
            this.isInPlayerRange = false;
            eArrowComp = transform.GetChild(0).gameObject.GetComponent<Arrow>();
            eArrowComp.SetArrowRotatingBool(this.isInPlayerRange);

            Debug.Log("enemy in swipe zone");
        }
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

}
