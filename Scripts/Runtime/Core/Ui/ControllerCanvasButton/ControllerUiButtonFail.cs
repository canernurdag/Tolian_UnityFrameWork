using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.SoundDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerUiButtonFail : ControllerCanvasButtons
    {
        [SerializeField] private SoundsUiDataSO _soundsUiDataSo;
        private SoundSystem _soundSystem;
        
        private void Start()
        {
            _soundSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSound>().SoundSystem;
        }

        public void ReplayButtonFunction()
        {
            //------------------SUPERSONIC WISDOM SDK---------------
            // ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerWisdomSDK>().NotifyLevelFailed();
        
            _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.ButtonSelectSFX, 1);
            DOVirtual.DelayedCall(0.5f, () => ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerLevel>().OpenTheSameLevel(true));
  
        }
    }

}

