using Tolian.Runtime.Systems.EventDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// This class controls all the C# events in the game via EventSystem.
    /// This class is provides Observer design pattern. 
    /// </summary>
    [RequireComponent(typeof(EventSystem))]
    public class ManagerEvent : MonoBehaviourService
    {
        #region REF
        public EventSystem EventSystem { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();
            EventSystem = GetComponent<EventSystem>();
        }
    }

}
