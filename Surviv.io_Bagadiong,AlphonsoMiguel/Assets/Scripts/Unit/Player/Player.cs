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
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

}
