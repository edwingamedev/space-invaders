using UnityEngine;

namespace EdwinGameDev.Weapons
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Pooling : MonoBehaviour
    {
        private List<IPool> objectPool;
        private Transform poolHolder;
        private IPool poolObject;
        private int poolSize;

        void Awake()
        {
            //setup
            ComponentAssigment();
        }

        private void ComponentAssigment()
        {
            //create the pools
            poolHolder = transform;
            objectPool = new List<IPool>();
        }

        public void CreatePool(IPool go, int amount)
        {
            // Assign the gameobject of the pool and the size of the pool
            poolObject = go;
            poolSize = 0;

            for (int i = 0; i < amount; i++)
            {
                // Add to the pool
                AddToThePool();
            }
        }

        private void AddToThePool()
        {
            // Create a new instance
            GameObject obj = Instantiate(poolObject.GetObject(), poolHolder);

            // Add to the respective pool
            IPool ip = obj.GetComponent<IPool>();
            objectPool.Add(ip);

            // Disable it
            objectPool[poolSize].DisableObject();

            // Increase the size number
            poolSize++;
        }

        public IPool ExtendPool()
        {
            // Add to the pool
            AddToThePool();

            // Get last object of the pool
            return objectPool[poolSize - 1];
        }

        public IPool GetFromPool()
        {
            for (int i = 0; i < objectPool.Count; i++)
            {
                //check if the object is disabled in the hierarchy
                if (!objectPool[i].isEnabled())
                {
                    //set it to active
                    objectPool[i].EnableObject();

                    return objectPool[i];
                }
            }

            // No available object found, extend the pool
            return ExtendPool();
        }
    }
}