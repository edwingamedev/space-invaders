namespace EdwinGameDev.Weapons
{
    using UnityEngine;

    public interface IPool
    {
        bool isEnabled();
        void EnableObject();
        void DisableObject();
        GameObject GetObject();
    }

}