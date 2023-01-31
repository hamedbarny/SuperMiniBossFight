using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Key_Binding : MonoBehaviour
{
    public static int Which_Ability=0;
    [SerializeField] GameObject uI_Key_Message;

    public void Btn_Ability_1()
    {
        Which_Ability = 1;
        uI_Key_Message.SetActive(true);
    }
    public void Btn_Ability_2()
    {
        Which_Ability = 2;
        uI_Key_Message.SetActive(true);
    }
    public void Btn_Ability_3()
    {
        Which_Ability = 3;
        uI_Key_Message.SetActive(true);
    }
}
