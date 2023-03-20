using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolComponent : MonoBehaviour
{
    public float patrolSpeed;
    public Transform[] patrolSpots;
    private int randPatrolSpot;

    void Start()
    {
        randPatrolSpot = Random.Range(0, patrolSpots.Length);
    }

}
