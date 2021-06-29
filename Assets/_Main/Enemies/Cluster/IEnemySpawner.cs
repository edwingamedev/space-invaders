using System;

namespace EdwinGameDev.Enemies
{
    public interface IEnemySpawner
    {
        IEnemy[,] ResetClusterPosition();
        IEnemy[,] SpawnEnemies(ClusterSetup clusterSetup);
    }
}