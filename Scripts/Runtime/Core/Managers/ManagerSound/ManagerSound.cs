using System;
using Tolian.Runtime.Systems.SaveDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using Tolian.Runtime.Systems.SoundDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// Manage Sounds Here
    /// </summary>
   
    [RequireComponent(typeof(SoundSystem))]
    public class ManagerSound : MonoBehaviourService
    {
        private SaveSystem _saveSystem;
        private SoundSystem _soundSystem;
        public SoundSystem SoundSystem
        {
            get
            {
                if (_saveSystem != null && _saveSystem.SaveState != null)
                {
                    bool isSoundOn = _saveSystem.SaveState.IsVibrationOn;
           
                    _soundSystem.SetPreventSound(!isSoundOn);
                }
     
                return _soundSystem;
            }
            private set { }
        }

        protected override void Awake()
        {
            base.Awake();
            _soundSystem = GetComponent<SoundSystem>();
        }

        private void Start()
        {
            _saveSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>().SaveSystem;
        }

    }
}
