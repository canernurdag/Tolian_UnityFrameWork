using Tolian.Runtime.Systems.ObjectPoolDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// This class controls object pools via "ObjectPoolSystem"
    /// </summary>
    [RequireComponent(typeof(ObjectPoolSystem))]
    public class ManagerObjectPool : MonoBehaviourService
    {
       public ObjectPoolSystem ObjectPoolSystem { get; private set; }

       protected override void Awake()
       {
           base.Awake();
           ObjectPoolSystem = GetComponent<ObjectPoolSystem>();
       }
       
    }
}

