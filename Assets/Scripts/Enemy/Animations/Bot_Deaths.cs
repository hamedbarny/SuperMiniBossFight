using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Deaths : StateMachineBehaviour
{
    GameObject go;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        go = animator.gameObject;
        go.GetComponent<Collider>().enabled = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        go.SetActive(false); 
    }


}
