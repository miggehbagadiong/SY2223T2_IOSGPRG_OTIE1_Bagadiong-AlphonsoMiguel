using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Powerup
{
    [SerializeField]
    public string name;


    [SerializeField]
    public string duration;

    [SerializeField]
    public UnityEvent startAction;

    [SerializeField]
    public UnityEvent endAction;

    public void End()
    {
        
    }

    void Update()
    {
        
    }
}
