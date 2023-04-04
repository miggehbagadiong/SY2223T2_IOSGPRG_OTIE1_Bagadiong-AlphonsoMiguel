using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [HideInInspector] public GameObject unitTarget;
    [HideInInspector] public EnemyWeaponInventory eWeaponInventory;

    [Header("Animator Parameters")]
    public Animator eAnimator;

    [Header("Detection Parameters")]
    public float eMoveSpeed;
    public float lineOfSight;
    public float shootingRange;

    [Header("Patrol Parameters")]
    public float ePatrolSpeed;

    [Header("Aim Component")]
    public float eOffset;

    //[Header("Unit Detection Awareness")]
    
    // [SerializeField] private float unitAwareDist;
    
    // other variables
    // private Vector2 uTargetDir;
    // public Vector2 DirectionToUnit { get; private set; }
    

    protected override void Start()
    {
        base.Start();

        this.uHealthComponent = GetComponent<HealthComponent>();
        this.eWeaponInventory = GetComponent<EnemyWeaponInventory>();
        this.eWeaponInventory.eCurrWeapon = SpawnManager.Instance.GetWeaponForEnemy();
        
        unitTarget = PlayerManager.Instance.GetPlayer().gameObject;
        //unitTarget = gameObject.GetComponent<Unit>();
        eAnimator = GetComponent<Animator>();

        StartPatrolling();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // player awareness controller reference implementation!
        // Vector2 enemyToUTargetVector = uTarget.position - transform.position;
        // DirectionToUnit = enemyToUTargetVector.normalized;

        DetectTarget();

    }

    private float GetDistanceFromTargetAndSelf()
    {
        return Vector2.Distance(unitTarget.transform.position, 
                    this.transform.position);
    }

    private void DetectTarget()
    {
        if (this.GetDistanceFromTargetAndSelf() <= lineOfSight && this.GetDistanceFromTargetAndSelf() > shootingRange)
        {
            // chasing behaviour
            eAnimator.SetBool("isPatrolling", false);
            eAnimator.SetBool("isChasing", true);
            eAnimator.SetFloat("enemySpeed", eMoveSpeed);
            // chasing paramter (rotation) insert here
            LookTowardsUnit();
           
        }
        else if (this.GetDistanceFromTargetAndSelf() <= shootingRange)
        {
            // attacking behaviour
            eAnimator.SetBool("isChasing", false);
            eAnimator.SetBool("isAttacking", true);
        }
        else
        {
            // patrolling behaviour
            eAnimator.SetFloat("enemyPatrolSpeed", ePatrolSpeed);
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

    private void LookTowardsUnit()
    {
        Vector3 dir = (unitTarget.GetComponent<Transform>().position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + eOffset, Vector3.forward);   
    }

    private void StartPatrolling()
    {
        eAnimator.SetFloat("enemyPatrolSpeed", ePatrolSpeed);
        eAnimator.SetBool("isPatrolling", true);
        eAnimator.SetBool("isChasing", false);
        eAnimator.SetBool("isAttacking", false);
    }

    // use this implementation only for that the enemy can pass through spawnedLootables onScene
    private void OnTriggerEnter2D(Collider2D target)
    {
        // implemented to avoid making lootables as obstacles
        if (target.gameObject.GetComponent<AmmoItem>())
        {
            //Debug.Log("Collided with " +  target.gameObject);
        }

        else if (target.gameObject.GetComponent<WeaponItem>())
        {
            //Debug.Log("Collided with " + target.gameObject);
        }
    }
}
