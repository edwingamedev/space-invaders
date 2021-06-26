using EdwinGameDev.Movement;
using EdwinGameDev.Projectile;
using EdwinGameDev.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private AMovementController movementController;

        private void Awake()
        {
            gameObject.tag = Tags.PLAYER;
        }

        private void Update()
        {
            movementController?.Move(Time.deltaTime * Vector2.right);
        }

        public void ReceiveDamage(int value)
        {
            Debug.Log("player Damage: " + value);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.BULLET))
            {
                col.GetComponent<IBullet>().ApplyDamage(this);
            }
        }
    }
}