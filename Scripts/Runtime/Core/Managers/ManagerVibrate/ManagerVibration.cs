using System;
using MoreMountains.NiceVibrations;
using Tolian.Runtime.Systems.SaveDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using Tolian.Runtime.Systems.VibrateDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    [RequireComponent(typeof(VibrateSystem))]
    public  class ManagerVibration : MonoBehaviourService
    {
        private SaveSystem _saveSystem;
        private VibrateSystem _vibrateSystem;
        public VibrateSystem VibrateSystem
        {
            get
            {
                if (_saveSystem != null && _saveSystem.SaveState != null)
                {
                    bool isVibrationOn = _saveSystem.SaveState.IsVibrationOn;
           
                    _vibrateSystem.SetPreventVibration(!isVibrationOn);
                }
             

                return _vibrateSystem;
            }
            private set { }
        }

        protected override void Awake()
       {
           base.Awake();
           VibrateSystem = GetComponent<VibrateSystem>();
       }

        private void Start()
        {
            _saveSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>().SaveSystem;
        }
    }

}

