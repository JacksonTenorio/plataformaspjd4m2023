using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update : StateMachineBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform limitPointA;
    public Transform limitPointB;
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 5f;

    private Transform target;
    private bool estaSeguindo = false;
    private bool isMovingTowardsPointA = true;

    public static EnemyController2 instance;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyController2.instance.AnimUpdate();
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
