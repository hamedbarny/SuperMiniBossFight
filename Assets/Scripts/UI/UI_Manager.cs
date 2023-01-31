using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject main, play, tutorial, setting, credit;
    private void Awake()
    {
        Btn_Main();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Btn_Main()
    {
        DisableAll();
        main.SetActive(true);
    }
    public void Btn_Play()
    {
        DisableAll();
        play.SetActive(true);
    }
    public void Btn_Tutorial()
    {
        DisableAll();
        tutorial.SetActive(true);
    }
    public void Btn_Setting()
    {
        DisableAll();
        setting.SetActive(true);
    }
    public void Btn_Credit()
    {
        DisableAll();
        credit.SetActive(true);
    }
    private void DisableAll()
    {
        main.SetActive(false);
        play.SetActive(false);
        setting.SetActive(false);
        credit.SetActive(false);
        tutorial.SetActive(false);

    }
}
