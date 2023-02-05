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
        CheckHealth();
    }

    protected virtual void LateUpdate()
    {

    }

    protected virtual void CheckHealth()
    {
        
    }
}
