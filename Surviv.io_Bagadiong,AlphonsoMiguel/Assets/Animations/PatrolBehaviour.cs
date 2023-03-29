using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    public float patrolSpeed;
    private PatrolSpot patrol;
    private int randomSpot;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      patrol = GameManager.Instance.patrolSpots.GetComponent<PatrolSpot>();
      randomSpot = Random.Range(0, patrol.patrollingPoints.Length);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (Vector2.Distance(animator.transform.position, patrol.patrollingPoints[randomSpot].position) > 0.2f)
       {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrol.patrollingPoints[randomSpot].position,
                patrolSpeed * Time.deltaTime);
       }
       else
       {
            randomSpot = Random.Range(0, patrol.patrollingPoints.Length);
       }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
