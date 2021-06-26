using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace EdwinGameDev.Enemies
{
    [CreateAssetMenu(menuName = "Enemy/Collection")]

    public class EnemyCollection : ScriptableObject
    {
        public List<EnemyProvider> enemies;

        public GameObject GetEnemy(EnemyType enemyType)
        {
            return enemies.FirstOrDefault(enemy => enemy.enemyType == enemyType).enemyPrefab;
        }
    }
}