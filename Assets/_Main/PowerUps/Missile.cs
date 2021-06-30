using EdwinGameDev.Events;
using EdwinGameDev.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private int killsToActivate;
    private int currentKills;

    public ScriptableEvent<int> onEnemyDied;

    public AWeaponController weapon;

    private void Awake()
    {
        onEnemyDied.Subscribe(AddGauge);
    }

    private void AddGauge(int value)
    {
        currentKills++;

        if (currentKills >= killsToActivate)
        {
            Activate();
        }
    }

    public void Activate()
    {
        currentKills = 0;

        // Single shot
        weapon.canShoot = true;
    }
}
