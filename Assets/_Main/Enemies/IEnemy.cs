using EdwinGameDev.Movement;
using EdwinGameDev.Weapons;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public interface IEnemy
    {
        int ScoreValue { get; }
        WeaponHolder GetWeapons { get; }
        IMovable Movable { get; }
        GameObject gameObject { get; }
    }
}