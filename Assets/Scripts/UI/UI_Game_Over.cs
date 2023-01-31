using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Game_Over : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(ChangeScene), 10);
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
