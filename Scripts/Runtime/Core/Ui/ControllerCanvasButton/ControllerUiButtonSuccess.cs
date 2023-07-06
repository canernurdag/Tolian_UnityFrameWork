using DG.Tweening;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.SoundDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerUiButtonSuccess : ControllerCanvasButtons
    {
        [SerializeField] private SoundsUiDataSO _soundsUiDataSo;
        private SoundSystem _soundSystem;

        private void Start()
        {
            _soundSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSound>().SoundSystem;
        }

        public void NextButtonFunction()
        {
            //------------------SUPERSONIC WISDOM SDK---------------
            // ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerWisdomSDK>().NotifyLevelCompleted();
        
            _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.ButtonSelectSFX, 1);
            DOVirtual.DelayedCall(0.5f, () => ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerLevel>().OpenNextLevelScene(true));
  
        }
    }
}

