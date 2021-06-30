using EdwinGameDev.Events;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineGunUIComponent : MonoBehaviour
{
    [SerializeField] protected ScriptableEvent<int> scriptableEvent;
    [SerializeField] protected TextMeshProUGUI uiText;
    [SerializeField] protected string text;

    private bool activated;
    private float cooldown = 0;

    private void Awake()
    {
        DisableUI();
        scriptableEvent.Subscribe(EnableUI);
    }

    private void Update()
    {
        if (activated)
        {
            SetText(Mathf.CeilToInt(cooldown - Time.time));

            if (Time.time > cooldown)
            {
                DisableUI();
            }
        }        
    }

    private void DisableUI()
    {
        uiText.text = string.Empty;
        activated = true;
    }

    private void EnableUI(int shootingTime)
    {
        cooldown = Time.time + shootingTime;
        activated = true;

        SetText(shootingTime);
    }

    private void SetText(int shootingTime)
    {
        uiText.text = text.Replace("$", shootingTime.ToString());
    }
}
