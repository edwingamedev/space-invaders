using System;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    [Serializable]
    public class EnemyProvider
    {
        public EnemyType enemyType;
        public GameObject enemyPrefab;
    }
}