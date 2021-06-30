using EdwinGameDev.Events;
using EdwinGameDev.Movement;
using EdwinGameDev.Settings;
using System;
using System.Collections;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class EnemyCluster : MonoBehaviour, IObserver
    {
        [SerializeField] private ClusterSetup clusterSetup;
        [SerializeField] private GameBounds gameBounds;
        [SerializeField] private ClusterMovement clusterMovement;
        [SerializeField] private IClusterWeaponController clusterWeapon = new BottomClusterWeapon(5);
        public ScriptableEvent<bool> onStageClear;
        public bool canMove;

        private IEnemy[,] enemies;

        private IEnemySpawner enemySpawner;
        private int enemiesDead;
        public ScriptableEvent<int> OnEnemyDied;

        private void Start()
        {
            enemySpawner = new ClusterEnemySpawner(gameBounds);
            SpawnRows();
        }

        private void Update()
        {
            clusterWeapon?.Shoot(enemies);

            if (canMove)
                clusterMovement.Move(enemies, Time.deltaTime, enemiesDead);
        }

        private void SpawnRows()
        {
            enemies = enemySpawner.SpawnEnemies(clusterSetup);
            SetCallback(enemies);
        }

        private void SetCallback(IEnemy[,] _enemies)
        {
            foreach (ISubject item in _enemies)
            {
                item.Subscribe(this);
            }
        }

        public void Respawn()
        {
            clusterWeapon = new BottomClusterWeapon(5);
            gameObject.SetActive(true);
            enemySpawner.ResetClusterPosition();
            enemiesDead = 0;
        }

        public void ReceiveNotification(ISubject subject)
        {
            enemiesDead++;

            OnEnemyDied?.Notify((subject as IEnemy).ScoreValue);

            if (enemiesDead >= enemies.Length)
            {
                enemiesDead = 0;

                onStageClear.Notify(true);
            }
        }
    }
}