using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_WarmupTo1HMagic : StateMachineBehaviour
{
    Transform _player, _boss;
    Boss_Health _health;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _health = animator.GetComponent<Boss_Health>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _boss = animator.transform;
        _boss.LookAt(_player);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_health.Percentage() <= 40) animator.SetInteger("Phase2", 1);
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss.LookAt(_player);
    }

}
