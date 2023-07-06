using Tolian.Runtime.Systems.SaveDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    [RequireComponent(typeof(SaveSystem))]
    public class ManagerSave : MonoBehaviourService
    {
       public SaveSystem SaveSystem { get; private set; }

       protected override void Awake()
       {
           base.Awake();
           SaveSystem = GetComponent<SaveSystem>();
       }
    }
}

