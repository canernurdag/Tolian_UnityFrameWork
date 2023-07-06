using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.SoundDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerUiButtonInGameButtons : ControllerCanvasButtons
    {
        [SerializeField] private SoundsUiDataSO _soundsUiDataSo;
        private SoundSystem _soundSystem;
        
        private void Start()
        {
            _soundSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSound>().SoundSystem;
        }
        public void SettingsButtonFunction()
        {
            ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>().ControllerUiCanvases.UiCanvasSystem.SetActivenessOfSpecificCanvas(CanvasType.CanvasSettings,true);
      
            var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
            managerGame.SetCurrentGameStateType(GameStateType.Menu);
      
            _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.PopUpSFX, 1);
        }

        public void ShopButtonFunction()
        {
            ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>().ControllerUiCanvases.UiCanvasSystem.SetActivenessOfAllCanvases(false);
            ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>().ControllerUiCanvases.UiCanvasSystem.SetActivenessOfSpecificCanvas(CanvasType.CanvasShop,true);
      
            var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
            managerGame.SetCurrentGameStateType(GameStateType.Menu);
      
        }
    }
}

