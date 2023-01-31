using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Difficulty : MonoBehaviour
{
    [SerializeField] Players player;
    [SerializeField] Bosses boss;
    [SerializeField] Enemy botMelee, botRange, botBoss;
    UI_Manager ui_man;

    private void Awake()
    {
        ui_man = gameObject.GetComponent<UI_Manager>();
    }
    public void Btn_Easy()
    {
        DifficultySetting(1);
    }
    public void Btn_Medium()
    {
        DifficultySetting(2);
    }
    public void Btn_Hard()
    {
        DifficultySetting(4);
    }

    private void DifficultySetting(int _diff)
    {
        PlayerDiff();
        BossDiff(_diff);
        BotsDiff(_diff);
        GoToTutorialPage();
    }
    private void GoToTutorialPage()
    {
        ui_man.Btn_Tutorial();
        //SceneManager.LoadScene(1);
    }
    public void Btn_Start()
    {
        SceneManager.LoadScene(1);
    }
    private void PlayerDiff()
    {
        player.health = 1000;
        player.fireBallDamage = 20;
        player.fireOrbDamage = 25;
        player.hellFireDamage = 50;
        player.canCast = true;
    }
    private void BossDiff(int diff)
    {
        boss.health = 500 + (diff * 250);
        boss.fireBallDamage = 15 * diff;
        boss.kickDamage = 5 * diff;
        //boss.spawnCount = 6 * diff;
    }
    private void BotsDiff(int diff)
    {
        botMelee.attackDamage = 10 + (diff * 5);
        botRange.attackDamage = 10 + (diff * 5);
        botBoss.attackDamage = 5 + (diff * 5);
    }
}
