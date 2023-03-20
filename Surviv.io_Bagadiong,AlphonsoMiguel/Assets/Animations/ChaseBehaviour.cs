using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
   private Transform playerTarget;
   public float enemySpeed;

   // start function
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      playerTarget = PlayerManager.Instance.GetPlayer().transform;
   }

   // update function
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if (animator.GetBool("isChasing") == true)
      {
         animator.transform.position = Vector2.MoveTowards(animator.transform.position, 
               playerTarget.position, animator.GetFloat("enemySpeed")*Time.deltaTime);
      }
      
   }

    // stop playing
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }
}
