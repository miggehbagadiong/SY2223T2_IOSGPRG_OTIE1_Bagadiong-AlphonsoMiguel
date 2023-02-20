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
    public Sprite realYellowArrow;

    public bool isArrowRotating;

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

    public void SetFinalYellowArrowRender(int index) 
    {
        arrowRender.sprite = yellowArrowDir[index - 1];
    }


    public void SetRotateArrowRender(int index)
    {
        StartCoroutine(RotateArrow(index));
    }

    public void StopRotateArrowRender(int index)
    {
        StopCoroutine(RotateArrow(index));
    }

    public bool SetArrowRotatingBool(bool setBool)
    {
        isArrowRotating = setBool;

        return isArrowRotating;
    }

    private IEnumerator RotateArrow(int finalRotArrIndex)
    {
        while (!isArrowRotating)
        {
            arrowRender.sprite = yellowArrowDir[Random.Range(0, yellowArrowDir.Length - 1)];

            yield return new WaitForSeconds(0.5f);
        }

        arrowRender.sprite = yellowArrowDir[finalRotArrIndex - 1];
        

    }
}
