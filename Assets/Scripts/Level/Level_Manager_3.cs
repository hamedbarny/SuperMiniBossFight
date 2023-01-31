using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager_3 : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private int levelCounter = 5;
    [SerializeField] private GameObject gateLevel1;
    public int counter;
    private void Awake()
    {
        counter = 0;
    }
    private void OnEnable()
    {
        Bot_Health.Bot_Dead += KilledBotCounter;
    }

    private void OnDisable()
    {
        Bot_Health.Bot_Dead -= KilledBotCounter;
    }
    private void KilledBotCounter()
    {
        counter++;
        if (counter >= levelCounter)
        {
            boss.SetActive(true);
            gateLevel1.GetComponent<Animator>().enabled = true;
           // print("asdasdsd");
        }
    }
}
