using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class SuperEnemyCluster : MonoBehaviour
    {
        [SerializeField] private List<EnemyCluster> enemyClusters;
        [SerializeField] private bool canMove;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float moveDown;

        [SerializeField] private float movementDelay;
        private float nextMovement;
        private int currentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            SetNextMovement();

            foreach (var item in enemyClusters)
            {
                item.SetEnemyBehaviourOnReachBorder(EnemyReachedBorder);
            }
        }

        private void EnemyReachedBorder()
        {
            moveSpeed *= -1;
            currentIndex = -1;

            foreach (var item in enemyClusters)
            {
                item.MoveDown(moveDown);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!canMove)
                return;


            if (Time.time > nextMovement)
            {
                SetNextMovement();

                enemyClusters[currentIndex].Move(Time.deltaTime * moveSpeed);

                currentIndex++;

                if (currentIndex >= enemyClusters.Count)
                {
                    //canMove = false;
                    currentIndex = 0;
                }
            }
        }

        private void SetNextMovement()
        {
            nextMovement = Time.time + movementDelay;
        }
    }
}