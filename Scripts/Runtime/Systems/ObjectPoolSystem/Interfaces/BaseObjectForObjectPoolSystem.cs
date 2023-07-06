using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Systems.EventDomain;
using UnityEngine;

namespace Tolian.Runtime.Systems.ObjectPoolDomain
{
    public abstract class BaseObjectForObjectPoolSystem : MonoBehaviour
    {
        #region REFERENCES
        public ObjectPoolType ObjectPoolType { get; protected set; }
        protected ManagerEvent _managerEvent;
        protected ManagerObjectPool _managerObjectPool;
        #endregion
        
        protected virtual void OnEnable()
        {
            _managerEvent = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>();
            _managerObjectPool = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerObjectPool>();
            
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().AddListener(DespawnObject);
        }

        
        protected virtual void OnDisable()
        {
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().RemoveListener(DespawnObject);
        }
        
        private void DespawnObject(GameStateType gameStateType)
        {
            if (gameStateType == GameStateType.LevelOpened)
            {
                if (gameObject.activeInHierarchy)
                {
                    _managerObjectPool.ObjectPoolSystem.Despawn(ObjectPoolType, this);
                }
            }
        }
        public abstract void ResetObject();

        public void SetObjectPoolType(ObjectPoolType objectPoolType)
        {
            ObjectPoolType = objectPoolType;
        }
    }
   
}

