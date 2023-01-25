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
    void SetRotatingArrowRender(int index)
    {

    }

}
