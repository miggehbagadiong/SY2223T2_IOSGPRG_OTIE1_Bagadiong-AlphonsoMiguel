using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.uHealthComponent = GetComponent<HealthComponent>();
        //UiManager.Instance.SetMaxHealth(this.uHealthComponent.GetMaxHealth());
        UiManager.Instance.SetHealth(this.uHealthComponent.GetHealth());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

}
