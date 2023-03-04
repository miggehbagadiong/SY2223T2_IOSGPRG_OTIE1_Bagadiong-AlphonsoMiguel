using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        SpawnManager.Instance.StartSpawning();
    }

    void Update()
    {

    }
}
