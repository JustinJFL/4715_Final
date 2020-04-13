using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_WanderingState : StateMachineBehaviour
{
    public float FieldOfViewAngle = 110f;
    public GameObject player;
    public float maxSightDistance;
    public float wanderTime;
    public float MaxWanderTime;

    private RaycastHit hit;
    private SCR_EnemyController enemy;
    private SCR_EnemyHealth enemyHealth;
    private SCR_GameManager gameManager;
    private NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<SCR_EnemyController>();
        enemyHealth = animator.GetComponent<SCR_EnemyHealth>();
        agent = animator.GetComponent<NavMeshAgent>();
        GameObject game = GameObject.FindWithTag("GameController");
        if (game == null)
        {
            Debug.Log("Game Manager not found");
        }
        gameManager = game.GetComponent<SCR_GameManager>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (wanderTime > 0)
        {
            animator.transform.Translate(Vector3.forward * enemy.moveSpeed);
            wanderTime -= Time.deltaTime;
        }
        else
        {
            wanderTime = Random.Range(1, MaxWanderTime);
            enemy.StartCoroutine(MovementPause(10f, animator));
            animator.transform.eulerAngles = new Vector3(0, Random.Range(-360, 360), 0);
        }

        Vector3 direction = player.transform.position - animator.transform.position;
        float angle = Vector3.Angle(direction, animator.transform.forward);

        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hit, maxSightDistance) || enemy.isPlayerSpotted)
        {
            Debug.Log("Angle test");
            enemy.StartCoroutine(MovementPause(10f, animator));
            if(angle < FieldOfViewAngle * .5f)
            {
                animator.SetBool("isPlayerSpotted", true);
                enemy.isPlayerSpotted = true;
                gameManager.groupAlert = true;
                //Debug.Log("SPOOOOOOTTED");


            }
        }
        Debug.DrawRay(animator.transform.position, player.transform.position,Color.red);
        if(enemyHealth.curHealth <=0)
        {
            animator.SetBool("isHealthZero", true);
        }
    }

    public IEnumerator MovementPause(float pauseTime,Animator animator)
    {
        Debug.Log("Enumerator Entered");
        animator.transform.Translate(Vector3.zero);
        yield return new WaitForSeconds(pauseTime);
        Debug.Log("Enumerator Exiting");
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
