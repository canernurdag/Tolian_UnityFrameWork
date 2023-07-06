using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Systems.DebuggerSystem;
using UnityEngine;

namespace Tolian.Runtime.Systems.ObjectPoolDomain
{
    public class ObjectPoolSystem : MonoBehaviour
    {
        public List<ObjectPool> ObjectPoolsList;
        
        protected void Awake()
        {
            InitObjectPools();
        }

        private void InitObjectPools()
        {
            for (int i = 0; i < ObjectPoolsList.Count; i++)
            {
                ObjectPoolsList[i].InitializePool();
            }
        }

        /// <summary>
        /// This function returns an object from the pool.
        /// </summary>
        /// <param name="poolType"></param>
        /// <returns></returns>
        public GameObject Spawn(ObjectPoolType poolType)
        {
            ObjectPool pool = GetObjectPool(poolType);
            if (pool == null) return null;
        
            GameObject clone = pool.GetNextObject();
            if (clone == null)  return null;
         
            clone.SetActive(true);
            
            return clone;
        }
            
        /// <summary>
        /// This function makes an objects returns to the pool. In the most cases, it is crucial to despawn objects before changing the scene.
        /// </summary>
        /// <param name="poolType"></param>
        /// <param name="baseObjectForObjectPoolSystem"></param>
        public void Despawn(ObjectPoolType poolType, BaseObjectForObjectPoolSystem baseObjectForObjectPoolSystem)
        {
            ObjectPool objectPool = GetObjectPool(poolType);
            
            baseObjectForObjectPoolSystem.transform.SetParent(objectPool.ParentGameObject.transform);

            if (!objectPool.InactiveObjectsDictionary.ContainsKey(baseObjectForObjectPoolSystem.GetInstanceID()))
            {
                objectPool.InactiveObjectsDictionary.Add(baseObjectForObjectPoolSystem.GetInstanceID(), baseObjectForObjectPoolSystem.gameObject);
            }
            
            baseObjectForObjectPoolSystem.ResetObject();
            baseObjectForObjectPoolSystem.gameObject.SetActive(false);
        }


        private ObjectPool GetObjectPool(ObjectPoolType poolType)
        {
            for (int i = 0; i < ObjectPoolsList.Count; i++)
            {
                if (ObjectPoolsList[i].ObjectPoolType == poolType)
                {
                    return ObjectPoolsList[i];
                }
            }

            return null;  
        } 
        [System.Serializable]
        public class ObjectPool
        {
            public ObjectPoolType ObjectPoolType;
            public BaseObjectForObjectPoolSystem Prefab;
            public int MaximumInstanceCount;
            
            [HideInInspector]
            public Dictionary<int, GameObject> InactiveObjectsDictionary;

            [HideInInspector]
            public GameObject ParentGameObject;
            
            public void InitializePool()
            {
                InactiveObjectsDictionary = new Dictionary<int, GameObject>();
                ParentGameObject = new GameObject("[" + ObjectPoolType + "]");
                DontDestroyOnLoad(ParentGameObject);

                GameObject cloneGameObject;
          

                for (int i = 0; i < MaximumInstanceCount; i++)
                {
                    cloneGameObject = Instantiate(Prefab.gameObject);
                    BaseObjectForObjectPoolSystem baseObjectForObjectPoolSystem =
                        cloneGameObject.GetComponent<BaseObjectForObjectPoolSystem>();
                    baseObjectForObjectPoolSystem.SetObjectPoolType(ObjectPoolType);
                    cloneGameObject.SetActive(false);
                    cloneGameObject.transform.SetParent(ParentGameObject.transform);
                    InactiveObjectsDictionary.Add(cloneGameObject.GetInstanceID(), cloneGameObject);
                }
            }

            
            public GameObject GetNextObject()
            {
                GameObject tempObject;
                
                if (InactiveObjectsDictionary.Count > 0)
                {
                    tempObject = InactiveObjectsDictionary.Values.ElementAt(0);
                    InactiveObjectsDictionary.Remove(InactiveObjectsDictionary.Keys.ElementAt(0));
                    return tempObject;
                }
                else
                {
                    string logMessage =
                        string.Format("PoolManager: {0} - passiveObjectsDictionary is empty. Instantiating new one.",
                            ObjectPoolType);
                    ManagerDebugger.Log(logMessage, null);
                    GameObject clone; 
                    clone = Instantiate(Prefab.gameObject);
                    clone.SetActive(false);
                    clone.transform.SetParent(ParentGameObject.transform);
                    InactiveObjectsDictionary.Add(clone.GetInstanceID(), clone);

                    tempObject = InactiveObjectsDictionary.Values.ElementAt(0);
                    InactiveObjectsDictionary.Remove(InactiveObjectsDictionary.Keys.ElementAt(0));
                    return tempObject;
                }
            }

            
        }
    }
}

