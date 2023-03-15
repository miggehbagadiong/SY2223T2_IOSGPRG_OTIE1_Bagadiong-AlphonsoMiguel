using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Rifle")]
public class Rifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        base.wCurrAmmo = this.wMaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
