using EdwinGameDev.Movement;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public interface IEnemy
    {
        IMovable movable { get; }
    }
}