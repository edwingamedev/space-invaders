using EdwinGameDev.Settings;
using System;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class ClusterEnemySpawner: IEnemySpawner
    {
        private readonly GameBounds gameBounds;
        private int rowsSpacing = 1;
        private int columnsSpacing = 1;
        private IEnemy[,] currentEnemyCluster;

        public ClusterEnemySpawner(GameBounds gameBounds)
        {
            this.gameBounds = gameBounds;
        }

        public IEnemy[,] SpawnEnemies(ClusterSetup clusterSetup)
        {
            int rows = clusterSetup.enemiesPerRow;
            int colums = clusterSetup.enemyRows.Length;

            currentEnemyCluster = new IEnemy[rows, colums];
            var spawnCentering = CalculateCenter(rows, colums);

            for (int j = colums - 1; j >= 0; j--)
            {
                var enemyCluster = new GameObject() { name = $"Enemies {j}" };

                for (int i = 0; i < rows; i++)
                {
                    var enemy = clusterSetup.enemyCollection.GetEnemy(clusterSetup.enemyRows[j]);
                    var spacing = new Vector2(spawnCentering.x + (rowsSpacing * i), spawnCentering.y + columnsSpacing * j);

                    var go = GameObject.Instantiate(enemy, spacing, Quaternion.identity, enemyCluster.transform);
                    go.name = $"Alien ({i},{j})";
                    currentEnemyCluster[i, j] = go.GetComponent<IEnemy>();
                }
            }

            return currentEnemyCluster;
        }

        public IEnemy[,] ResetClusterPosition()
        {
            int rows = currentEnemyCluster.GetLength(0);
            int colums = currentEnemyCluster.GetLength(1);
            var spawnCentering = CalculateCenter(rows, colums);

            for (int j = colums - 1; j >= 0; j--)
            {                
                for (int i = 0; i < rows; i++)
                {
                    var spacing = new Vector2(spawnCentering.x + (rowsSpacing * i), spawnCentering.y + columnsSpacing * j);

                    // Set position
                    currentEnemyCluster[i, j].gameObject.transform.position = spacing;

                    // Enable GameObject
                    currentEnemyCluster[i, j].gameObject.SetActive(true);
                }
            }

            return currentEnemyCluster;
        }

        private Vector2 CalculateCenter(int rows, int colums)
        {
            float centerX = (gameBounds.MIN_X + gameBounds.MAX_X) / 2;
            float centerY = gameBounds.MAX_Y - colums;

            return new Vector2(centerX - Mathf.FloorToInt(rows / 2), centerY);
        }
    }
}