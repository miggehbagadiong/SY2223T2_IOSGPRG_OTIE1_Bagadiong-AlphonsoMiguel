using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    // implement player score here!!
    [HideInInspector] public int playerScore = 0;
    [HideInInspector] public float killScore = 0;

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public float GetKillScore()
    {
        return killScore;
    }

    public int AddScore (int addPoint)
    {
        playerScore += addPoint;
        return playerScore;
    }

    public float AddKills (float addPoint)
    {
        killScore += addPoint;
        return killScore;
    }

}
