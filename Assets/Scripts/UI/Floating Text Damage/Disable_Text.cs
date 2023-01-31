using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Text : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DisableTextBox), 4);
    }
    void DisableTextBox()
    {
        this.gameObject.SetActive(false);
    }
}
