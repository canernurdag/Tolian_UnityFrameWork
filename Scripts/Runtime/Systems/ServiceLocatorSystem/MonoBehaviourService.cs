using Tolian.Runtime.Core.Managers;
using UnityEngine;

namespace Tolian.Runtime.Systems.ServiceLocatorDomain
{
    /// <summary>
    /// For SERVICE LOCATOR Design Pattern => Base and abstract class for MonobehaviourServices. 
    /// </summary>
    public abstract class MonoBehaviourService : MonoBehaviour, IService
    {
        protected virtual void Awake()
        {
            RegisterToManagerServiceLocator();
        }

        protected virtual void OnDisable()
        {
            UnregisterFromManagerServiceLocator();
        }

    
        public void RegisterToManagerServiceLocator()
        {
            if(!ManagerServiceLocator.Instance) return;
            
            ManagerServiceLocator.Instance.ServiceLocatorSystem.Register(this);
        }

        public void UnregisterFromManagerServiceLocator()
        {
            if(!ManagerServiceLocator.Instance) return;

            ManagerServiceLocator.Instance.ServiceLocatorSystem.Unregister(this);   
        }
    }

}
