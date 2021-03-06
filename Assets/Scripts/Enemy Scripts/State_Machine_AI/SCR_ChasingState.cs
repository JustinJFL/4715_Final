﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_ChasingState : StateMachineBehaviour
{
    public float moveSpeed = 4;
    //public SCR_PlayerController player = FindObjectOfType<SCR_PlayerController>();
    private NavMeshAgent agent;
    public GameObject player;

    private SCR_EnemyHealth health;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        health = animator.GetComponent<SCR_EnemyHealth>();
        agent = animator.GetComponent<NavMeshAgent>();
        animator.transform.LookAt(player.transform);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent.SetDestination(player.transform.position);

        if(health.curHealth <= 0)
        {
            animator.SetBool("isHealthZero", true);
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
