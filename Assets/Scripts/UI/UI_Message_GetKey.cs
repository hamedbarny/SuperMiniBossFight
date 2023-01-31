using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Message_GetKey : MonoBehaviour
{
    [SerializeField] KeyBinding keySO;
    [SerializeField] TextMeshProUGUI txt_1, txt_2, txt_3;
    Event e;
    int _number;
    bool isUnique = false;
    private void OnGUI()
    {
        if (Input.anyKey)
        {
            e = Event.current;
            if (!e.isKey 
                || e.keyCode == KeyCode.Escape
                || e.keyCode == KeyCode.Space
                || e.keyCode == KeyCode.W
                || e.keyCode == KeyCode.A
                || e.keyCode == KeyCode.S
                || e.keyCode == KeyCode.D)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _number = UI_Key_Binding.Which_Ability;
                SetKeyBind(_number);
            }
        }
    }
    private void SetKeyBind(int number)
    {
        isUnique = false;
        e = Event.current;
        CheckIfUnique(e.keyCode);
        if (isUnique)
        {
            switch (number)
            {
                case 1:
                    keySO.Ability_1_Key = e.keyCode;
                    txt_1.text = e.keyCode.ToString();
                    this.gameObject.SetActive(false);
                    break;
                case 2:
                    keySO.Ability_2_Key = e.keyCode;
                    txt_2.text = e.keyCode.ToString();
                    this.gameObject.SetActive(false);
                    break;
                case 3:
                    keySO.Ability_3_Key = e.keyCode;
                    txt_3.text = e.keyCode.ToString();
                    this.gameObject.SetActive(false);
                    break;
            }
        }

    }

    private void CheckIfUnique(KeyCode _key)
    {
        if ((_key != keySO.Ability_1_Key) && (_key != keySO.Ability_2_Key) && (_key != keySO.Ability_3_Key))
        {
            isUnique = true;
        }
        else this.gameObject.SetActive(false);
    }
}
