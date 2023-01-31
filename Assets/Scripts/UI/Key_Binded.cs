using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key_Binded : MonoBehaviour
{
    [SerializeField] KeyBinding keySO;
    [SerializeField] TextMeshProUGUI txt_1, txt_2, txt_3;

    private void Start()
    {
        if (keySO.Ability_1_Key.ToString().Contains("Alpha"))
        {
            txt_1.text = keySO.Ability_1_Key.ToString().Remove(0, 5);
        }
        else
            txt_1.text = keySO.Ability_1_Key.ToString();

        if (keySO.Ability_2_Key.ToString().Contains("Alpha"))
        {
            txt_2.text = keySO.Ability_2_Key.ToString().Remove(0, 5);
        }
        else
            txt_2.text = keySO.Ability_2_Key.ToString();

        if (keySO.Ability_3_Key.ToString().Contains("Alpha"))
        {
            txt_3.text = keySO.Ability_3_Key.ToString().Remove(0, 5);
        }
        else
            txt_3.text = keySO.Ability_3_Key.ToString();
    }
}
