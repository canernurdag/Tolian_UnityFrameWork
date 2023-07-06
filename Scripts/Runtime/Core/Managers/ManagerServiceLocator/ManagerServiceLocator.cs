using Tolian.Runtime.Abstract.DesignPatterns.SingletonSystem;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;


namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// This is the main class that gives us to reach the essential classes.
    /// This class is using Singleton design patterns. Therefore, it can be accessed with static instance.
    /// In order to add new class, please refer to "MonoBehaviourService" classes. The new classes should be inherited from "MonoBehaviourService" and automatically registered to "ServiceLocatorSystem"
    /// 
    /// </summary>
    [DefaultExecutionOrder(-50)]
    [RequireComponent(typeof(ServiceLocatorSystem))]
    public class ManagerServiceLocator : Singleton<ManagerServiceLocator>
    {
        #region REFERENCES
        public ServiceLocatorSystem ServiceLocatorSystem { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();
            ServiceLocatorSystem = GetComponent<ServiceLocatorSystem>();
        }
    }
    
}
