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
    public Sprite setYellowArrowDir;

    [HideInInspector] bool isArrowRotating;

    void Start()
    {
        arrowRender = GetComponent<SpriteRenderer>();
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

    public void SetRotatingArrowRender(bool isRotating)
    {
        StartCoroutine(RotateArrow(isRotating));
    }

    public void SetFinalRotatingArrow(Sprite finalArrow)
    {

    }

    public IEnumerator RotateArrow(bool isRotating)
    {
        while (isRotating)
        {
            arrowRender.sprite = yellowArrowDir[Random.Range(0, yellowArrowDir.Length - 1)];

            yield return new WaitForSeconds(0.5f);
        }



    }
}
