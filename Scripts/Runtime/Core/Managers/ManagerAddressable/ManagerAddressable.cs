using Tolian.Runtime.Systems.AddressablesDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;


namespace Tolian.Runtime.Core.Managers
{
    [RequireComponent(typeof(AddressablesSystem))]
    public class ManagerAddressable : MonoBehaviourService
    {
        public AddressablesSystem AddressablesSystem { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            AddressablesSystem = GetComponent<AddressablesSystem>();
        }
    }

}
