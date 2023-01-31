using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Floating_Damage : MonoBehaviour
{
    bool isShowingDone = false, isShowingTaken = false;
    private Queue<int> DamageDone = new Queue<int>(), DamageTaken = new Queue<int>();
    private void OnEnable()
    {
        Player_Ability_Fire.PlayerDamageDone += ShowDamageDone;
        Ability_2.PlayerDamageDone += ShowDamageDone;
        Damage_Ability_3.PlayerDamageDone += ShowDamageDone;
        Player_Health.DamageTaken += ShowDamageTaken;
    }
    private void OnDisable()
    {
        Player_Ability_Fire.PlayerDamageDone -= ShowDamageDone;
        Ability_2.PlayerDamageDone -= ShowDamageDone;
        Damage_Ability_3.PlayerDamageDone -= ShowDamageDone;
        Player_Health.DamageTaken -= ShowDamageTaken;
    }

    private void FixedUpdate()
    {
        CheckQueue();
    }
    private void ShowDamageDone(int Damage)
    {
        DamageDone.Enqueue(Damage);
    }
    private void ShowDamageTaken(int Damage)
    {
        DamageTaken.Enqueue(Damage);
    }
    private void CheckQueue()
    {
        if (!isShowingDone)
        {
            if (DamageDone.Count > 0)
            {
                StartCoroutine(WaitForMsg());
                CreateMessageAndActive_Done(DamageDone.Dequeue());
            }

        }
        if (!isShowingTaken)
        {
            if (DamageTaken.Count > 0)
            {
                StartCoroutine(WaitForMsg());
                CreateMessageAndActive_Taken(DamageTaken.Dequeue());
            }
        }
    }

    private void CreateMessageAndActive_Done(int Damage)
    {
        GameObject floatingText = Text_Box_Pooling.SharedInstance.GetPooledObject();
        if (floatingText != null)
        {
            floatingText.GetComponent<TextMeshProUGUI>().SetText(Damage.ToString());
            floatingText.SetActive(true);
        }
    }

    private void CreateMessageAndActive_Taken(int Damage)
    {
        GameObject floatingText = Text_Box_Enemy_Pooling.SharedInstance.GetPooledObject();
        if (floatingText != null)
        {
            floatingText.GetComponent<TextMeshProUGUI>().SetText(Damage.ToString());
            floatingText.SetActive(true);
        }
    }

    IEnumerator WaitForMsg()
    {
        isShowingDone = true;
        isShowingTaken = true;
        yield return new WaitForSeconds(.08f);
        isShowingDone = false;
        isShowingTaken = false;
    }
}
