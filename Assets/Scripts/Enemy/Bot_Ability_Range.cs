using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Ability_Range : Bot_Ability
{
    //public GameObject fireBall;
    public Transform hand;

    public override void Attack()
    {

        GameObject fireBall = Bot_Ability_Pooling.SharedInstance.GetPooledObject();
        if (fireBall != null)
        {
            fireBall.transform.SetPositionAndRotation(hand.position, this.transform.rotation);
            fireBall.SetActive(true);
        }
        //Instantiate(fireBall, hand.position, this.transform.rotation);
    }
}