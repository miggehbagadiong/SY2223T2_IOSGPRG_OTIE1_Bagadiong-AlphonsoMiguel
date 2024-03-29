using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [Header ("Self Reference")]
    public Player player;
    

    public Player GetPlayer()
    {
        return player;
    }

    public WeaponInventory GetPlayerInventory()
    {
        return player.GetComponent<WeaponInventory>();
    }

    [Header("Player Component References")]
    public Joystick pMoveJoystick;
    public Joystick pAimJoystick;
    

}
