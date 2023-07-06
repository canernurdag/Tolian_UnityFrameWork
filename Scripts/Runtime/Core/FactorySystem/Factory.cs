using Tolian.Runtime.Core.Interfaces;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Systems.ObjectPoolDomain;
using UnityEngine;

namespace Tolian.Runtime.Abstract.DesignPatterns.FactorySystem
{
    /// <summary>
    /// For ABSTRACT FACTORY Design Pattern => Base and abstract class for Factories. 
    /// </summary>
    public abstract class Factory : MonoBehaviour, IProvideObject
    {
        #region REFERENCES
        protected ManagerObjectPool _managerObjectPool;
        #endregion

        private void Start()
        {
            _managerObjectPool = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerObjectPool>();
        }
        
        public virtual GameObject GetObjectFromObjectPool(ObjectPoolType targetObjectPoolType)
        {
            GameObject newGameObject = _managerObjectPool.ObjectPoolSystem.Spawn(targetObjectPoolType);
            newGameObject.transform.SetParent(transform);

            return newGameObject;
        }
        

        public virtual GameObject GetObjectFromPrefab(GameObject targetPrefab)
        {
            GameObject newGameObject = Instantiate(targetPrefab);
            newGameObject.transform.SetParent(transform);

            return newGameObject;
        }
    }
    
}
