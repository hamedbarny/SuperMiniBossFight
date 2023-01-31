using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Boss : MonoBehaviour
{
    Transform _cam;
    private void Awake()
    {
        _cam = Camera.main.transform;
    }
    private void FixedUpdate()
    {
        transform.LookAt(_cam);
    }
}
