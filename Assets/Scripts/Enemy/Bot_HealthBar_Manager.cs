using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_HealthBar_Manager : MonoBehaviour
{
    private GameObject mainCamera;
    private MeshRenderer meshRenderer;
    private MaterialPropertyBlock matBlock;
    private Bot_Health bot_Health;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        matBlock = new MaterialPropertyBlock();
        meshRenderer = GetComponent<MeshRenderer>();
        bot_Health = GetComponentInParent<Bot_Health>();
    }
    private void Update()
    {
            AlignCamera();
            UpdateParams();
        
    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        //matBlock.SetFloat("_Fill", bot_Health.currentHealth / (float)bot_Health.maxHealth);
        float offSetX = 0.5f - (bot_Health.currentHealth / (float)bot_Health.maxHealth) *0.5f;
        if (offSetX > 0.5f) offSetX = 0.5f;
        matBlock.SetVector("_MainTex_ST", new Vector4(0.5f, 1f, offSetX, 0f));
        meshRenderer.SetPropertyBlock(matBlock);
    }

    private void AlignCamera()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
