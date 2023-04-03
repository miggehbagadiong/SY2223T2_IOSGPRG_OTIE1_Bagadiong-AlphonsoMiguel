using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    // sample format for making event system on this state
    public event Action OnPlayerDeath;

    public void InvokePlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public event Action OnEnemyDeath;

    public void InvokeEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }

    public event Action OnPlayerWin;

    public void InvokePlayerWin()
    {
        OnPlayerWin?.Invoke();
    }
}
