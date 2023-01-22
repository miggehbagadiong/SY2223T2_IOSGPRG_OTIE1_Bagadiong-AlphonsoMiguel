using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [HideInInspector] public Arrow enemyArrow;

    // Start is called before the first frame update
    void Start()
    {
        enemyArrow = GetComponent<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
