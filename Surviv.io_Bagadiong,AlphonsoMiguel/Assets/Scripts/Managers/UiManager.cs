using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    // variable parameters
    [Header("Health Bar Parameters")]
    public Slider slider;
    public HealthBar healthBar;


    // functions and content
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#region Player Health

public void SetMaxHealth(int refHealth)
{
    slider.maxValue = refHealth;
    slider.value = refHealth;
}

public void SetHealth(int refHealth)
{
    slider.value = refHealth;
}

#endregion

}
