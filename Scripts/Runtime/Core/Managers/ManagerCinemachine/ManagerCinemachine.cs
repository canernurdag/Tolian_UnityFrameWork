using Tolian.Runtime.Systems.CinemachineDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// This class handles all Cinemachine related operations via "CinemachineSystem"
    /// </summary>
    
    [RequireComponent(typeof(CinemachineSystem))]
    public class ManagerCinemachine : MonoBehaviourService
    {
       public CinemachineSystem CinemachineSystem { get; private set; }

       protected override void Awake()
       {
           base.Awake();
           CinemachineSystem = GetComponent<CinemachineSystem>();
       }
    }

}
