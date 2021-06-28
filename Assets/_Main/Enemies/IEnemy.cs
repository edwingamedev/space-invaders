using EdwinGameDev.Movement;
using EdwinGameDev.Weapons;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public interface IEnemy
    {
        WeaponHolder GetWeapons { get; }
        IMovable Movable { get; }
    }
}