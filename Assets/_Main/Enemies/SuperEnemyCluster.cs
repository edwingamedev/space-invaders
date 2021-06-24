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

        [SerializeField] private float movementDelay;
        private float nextMovement;
        private int currentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!canMove)
                return;


            if (Time.time > nextMovement)
            {
                nextMovement = Time.time + movementDelay;

                Debug.Log("Timer");


                enemyClusters[currentIndex].StartMovement();
                currentIndex++;

                if (currentIndex >= enemyClusters.Count)
                {
                    canMove = false;
                    currentIndex = 0;
                }
            }
        }
    }
}