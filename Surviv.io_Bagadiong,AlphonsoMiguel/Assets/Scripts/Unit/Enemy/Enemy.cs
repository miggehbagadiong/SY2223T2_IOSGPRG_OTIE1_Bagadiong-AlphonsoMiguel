using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [HideInInspector] public GameObject unitTarget;

    [Header("Animator Parameters")]
    public Animator eAnimator;

    [Header("Detection Parameters")]
    public float eMoveSpeed;
    public float lineOfSight;
    public float shootingRange;
    public SphereCollider detectionSphere;

    [Header("Patrol Parameters")]
    public float ePatrolSpeed;

    protected override void Start()
    {
        base.Start();

        this.uHealthComponent = GetComponent<HealthComponent>();

        unitTarget = PlayerManager.Instance.GetPlayer().gameObject;
        eAnimator = GetComponent<Animator>();
        eAnimator.SetBool("isPatrolling", true);
        eAnimator.SetFloat("patrolSpeed", ePatrolSpeed);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        DetectTarget();

    }

    private float GetDistanceFromTargetAndSelf()
    {
        return Vector2.Distance(unitTarget.transform.position, 
                    this.transform.position);
    }

    private void DetectTarget()
    {
        if (this.GetDistanceFromTargetAndSelf() < lineOfSight && this.GetDistanceFromTargetAndSelf() > shootingRange)
        {
            eAnimator.SetBool("isPatrolling", false);
            eAnimator.SetBool("isChasing", true);
            eAnimator.SetFloat("enemySpeed", eMoveSpeed);
        }
        else if (this.GetDistanceFromTargetAndSelf() <= shootingRange)
        {
            eAnimator.SetBool("isChasing", false);
            eAnimator.SetBool("isAttacking", true);
        }
        else
        {
            // set the parameter to patrol only
            eAnimator.SetFloat("patrolSpeed", ePatrolSpeed);
            eAnimator.SetBool("isPatrolling", true);
            eAnimator.SetBool("isChasing", false);
            eAnimator.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void StartPatrolling()
    {
        eAnimator.SetFloat("patrolSpeed", ePatrolSpeed);
        eAnimator.SetBool("isPatrolling", true);
        eAnimator.SetBool("isChasing", false);
        eAnimator.SetBool("isAttacking", false);
    }
}
