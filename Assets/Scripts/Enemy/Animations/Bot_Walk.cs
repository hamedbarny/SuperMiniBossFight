using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot_Walk : StateMachineBehaviour
{
    [SerializeField] Enemy enemySO;
    private float attackRange;
    Transform player;
    Rigidbody rb;
    NavMeshAgent nma;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();
        nma = animator.GetComponent<NavMeshAgent>();
        attackRange = enemySO.attackRange;
        nma.speed = enemySO.speed;
        nma.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        rb.transform.LookAt(target);

        nma.SetDestination(target);
        nma.stoppingDistance = attackRange;
        if(Vector3.Distance(rb.position , target) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        nma.isStopped = true;
    }

}
