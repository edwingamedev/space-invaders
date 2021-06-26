using UnityEngine;

namespace EdwinGameDev.Enemies
{
    [CreateAssetMenu(menuName = "Enemy/ClusterSetup")]

    public class ClusterSetup : ScriptableObject
    {
        public EnemyCollection enemyCollection;
        public int enemiesPerRow = 11;
        public EnemyType[] enemyRows;
    }
}