using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    // sample format for making event system on this state
    public event Action OnPickupCollected;

    public void InvokePickupCollected()
    {
        OnPickupCollected?.Invoke();
    }

}
