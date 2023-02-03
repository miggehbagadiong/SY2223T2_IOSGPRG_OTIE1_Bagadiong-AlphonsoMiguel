using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ArrowDirection
{
    Up = 1,
    Right = 2,
    Down = 3,
    Left = 4
};

public class Arrow : Singleton<Arrow>
{ 
    public SpriteRenderer arrowRender;

    public Sprite[] greenArrowDir;
    public Sprite[] redArrowDir;
    public Sprite[] yellowArrowDir;

    [HideInInspector] bool isArrowRotating = true;

    void Start()
    {
        arrowRender= GetComponent<SpriteRenderer>();
    }

    public void SetArrowRender(int index, bool isArrowNormalDir)
    {
        if (isArrowNormalDir)
        {
            arrowRender.sprite = greenArrowDir[index - 1];
        }
        else
        {
            arrowRender.sprite = redArrowDir[index - 1];
        }
    }

    // latter milestone
    public void SetRotatingArrowRender()
    {
       
        StartCoroutine(RotateArrow());

        /*
         
        NOTE: try using update to make the arrow rotate.

         */
    }


    public IEnumerator RotateArrow()
    {
        int randomRotArrowVal = Random.Range(0, yellowArrowDir.Length);

        if (isArrowRotating == true)
        {
            while (isArrowRotating == true)
            {
                arrowRender.sprite = yellowArrowDir[randomRotArrowVal];
            }
        }

        yield return new WaitForSeconds(2f);

        isArrowRotating = false;
    }
}
