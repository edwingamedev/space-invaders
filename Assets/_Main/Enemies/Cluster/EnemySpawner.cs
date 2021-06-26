using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class EnemySpawner
    {
        private readonly GameBounds gameBounds;
        private int rowsSpacing = 1;
        private int columnsSpacing = 1;

        public EnemySpawner(GameBounds gameBounds)
        {
            this.gameBounds = gameBounds;
        }

        public IEnemy[,] SpawnEnemies(ClusterSetup clusterSetup)
        {
            int rows = clusterSetup.enemiesPerRow;
            int colums = clusterSetup.enemyRows.Length;

            var enemies = new IEnemy[rows, colums];
            var spawnCentering = CalculateCenter(rows, colums);

            for (int j = colums - 1; j >= 0; j--)
            {
                var enemyCluster = new GameObject() { name = $"Enemies {j}" };

                for (int i = 0; i < rows; i++)
                {
                    var enemy = clusterSetup.enemyCollection.GetEnemy(clusterSetup.enemyRows[j]);
                    var spacing = new Vector2(spawnCentering.x + (rowsSpacing * i), spawnCentering.y + columnsSpacing * j);

                    enemies[i, j] = Object.Instantiate(enemy, spacing, Quaternion.identity, enemyCluster.transform).GetComponent<IEnemy>();
                }
            }

            return enemies;
        }

        private Vector2 CalculateCenter(int rows, int colums)
        {
            float centerX = (gameBounds.MIN_X + gameBounds.MAX_X) / 2;
            float centerY = gameBounds.MAX_Y - colums;

            return new Vector2(centerX - Mathf.FloorToInt(rows / 2), centerY);
        }
    }
}