using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ArrowDirection
{
    North = 1,
    East = 2,
    South = 3,
    West = 4
};

public class Arrow : Singleton<Arrow>
{
    public ArrowDirection arrowDir;

    public SpriteRenderer arrowRender;

    public Sprite[] greenArrowDir;
    public Sprite[] redArrowDir;

    void Start()
    {
        arrowRender= GetComponent<SpriteRenderer>();

        // temporary for now
        SetArrowRender((int)arrowDir, true);
    }

    void Update()
    {
        
    }

    void SetArrowRender(int index, bool isArrowOpposite)
    {
        if (isArrowOpposite)
        {
            arrowRender.sprite = greenArrowDir[index - 1];
        }
        else
        {
            arrowRender.sprite= redArrowDir[index - 1];
        }
    }

    // latter milestones
    void SetRotatingArrowRender(int index)
    {

    }

}
