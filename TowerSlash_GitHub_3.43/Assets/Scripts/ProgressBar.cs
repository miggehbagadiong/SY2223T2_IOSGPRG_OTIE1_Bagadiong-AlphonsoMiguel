using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : Singleton<ProgressBar>
{
    public float max;
    public float curr;
    public Image mask;
    public Image fill;

    public GameObject DashButton;


    void Start()
    {
        DashButton.SetActive(false);
    }

    void Update()
    {
        GetCurrentFill();
        CheckIfMax();
    }

    void GetCurrentFill()
    {

        float fillAmount = curr / max;
        mask.fillAmount = fillAmount;
    }

    void CheckIfMax()
    {
        if (curr >= max)
        {
            DashButton.SetActive(true);
        }
        else if (curr < max) 
        {
            DashButton.SetActive(false);    
        }
    }

    public float AddBar(float addToBar, float barPercent)
    {
        curr += (addToBar * barPercent);

        return curr;
    }

}
