using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int lifePoint;

    public int TakeDamage(int dmg)
    {
        lifePoint -= dmg;

        return lifePoint;
    }

    public int AddLifePoint(int addLP)
    {
        lifePoint += addLP;

        return lifePoint;
    }

    public int GetLifePoint()
    {
        return lifePoint;
    }

}
