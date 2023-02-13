using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    [SerializeField] protected HealthComponent unitHealth;
    
    protected virtual void Start()
    { 

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
    protected virtual void LateUpdate() 
    {
        
    }

    public HealthComponent GetLifeComponent()
    {
        return unitHealth;
    }
}
