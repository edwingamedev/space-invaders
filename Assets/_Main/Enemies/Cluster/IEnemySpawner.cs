namespace EdwinGameDev.Enemies
{
    public interface IEnemySpawner
    {
        IEnemy[,] SpawnEnemies(ClusterSetup clusterSetup);
    }
}