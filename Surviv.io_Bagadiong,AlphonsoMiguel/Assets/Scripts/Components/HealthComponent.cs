using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;

    void Start()
    {
        currHealth = maxHealth;
    }

    public int TakeDamage(int dmg)
    {
        currHealth -= dmg;

        return currHealth;
    }

    public int GetHealth()
    {
        return currHealth;
    }

}
