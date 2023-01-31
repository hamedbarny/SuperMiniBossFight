using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_Ability_Call_1 : MonoBehaviour
{
    public static event Action BossAbilityCall_1;

    public void Ability_Cast_1()
    {
        BossAbilityCall_1?.Invoke();
    }
}
