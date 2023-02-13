using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Singleton<Powerup>
{
    [HideInInspector] float powerupChance;
    [HideInInspector] int additionalLife = 1;


    public int PowerupAfterKill(int addPoint)
    {
        powerupChance = Random.Range(0.01f, 1.0f);

        if (powerupChance <= 0.03f)
        {
            addPoint += additionalLife;

            return addPoint;
        }
        else
        {
            return addPoint;
        }
    }

    public Unit PowerupAfterKill(Unit unit)
    {
        powerupChance = Random.Range(0.01f, 1.0f);

        if (powerupChance <= 0.03f)
        {
            unit.GetComponent<Unit>().GetLifeComponent().GetComponent<HealthComponent>().AddLifePoint(additionalLife);

            return unit;
        }
        else
        {
            return unit;
        }
    }
}
