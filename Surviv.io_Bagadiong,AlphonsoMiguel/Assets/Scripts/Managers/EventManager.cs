using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    // sample format for making event system on this state
    public event Action<AmmoItem> OnAmmoPickupCollected;

    public void InvokeAmmoCollected(AmmoItem ammoItem)
    {
        OnAmmoPickupCollected?.Invoke(ammoItem);
    }

    public event Action<WeaponItem> OnWeaponPickupCollected;
    
    public void InvokeWeaponCollected(WeaponItem weaponItem)
    {
        OnWeaponPickupCollected?.Invoke(weaponItem);
    }

    public event Action OnWeaponNeedReload;

    public void InvokeNeedReload()
    {
        OnWeaponNeedReload?.Invoke();
    }

}
