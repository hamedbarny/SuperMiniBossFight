using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ability_Disable_1 : MonoBehaviour
{
    bool isFirstTime = true;
    [SerializeField] List<GameObject> orbs;
    private void OnEnable()
    {
        if (!isFirstTime)
        {
            Invoke(nameof(Deavtivator), 4);
        }
        else if (isFirstTime) isFirstTime = false;
    }
    private void OnDisable()
    {
        Toggler();
    }

    private void Deavtivator()
    {
        this.gameObject.SetActive(false);
    }
    private void Toggler()
    {
        foreach(GameObject go in orbs)
        {
            go.SetActive(false);
            go.SetActive(true);
            //go.transform.localPosition = Vector3.zero;
        }
    }
}
