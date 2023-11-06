using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : StateMachineBehaviour
{
    private EnemyController2 enemy;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject.GetComponent<EnemyController2>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.isMovingTowardsPointA)
        {
            enemy.transform.eulerAngles = (Vector3)new Vector2(0f, 0f);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.pointA.position, enemy.moveSpeed * Time.deltaTime);

            if (Vector2.Distance(enemy.transform.position, enemy.pointA.position) < 0.1f)
            {
                enemy.isMovingTowardsPointA = false;
            }
        }
        else
        {
            enemy.transform.eulerAngles = (Vector3)new Vector2(0f, 180f);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.pointB.position, enemy.moveSpeed * Time.deltaTime);

            if (Vector2.Distance(enemy.transform.position, enemy.pointB.position) < 0.1f)
            {
                enemy.isMovingTowardsPointA = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
