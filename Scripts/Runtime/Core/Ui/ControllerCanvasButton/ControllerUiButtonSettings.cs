using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.SoundDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    [DefaultExecutionOrder(50)]
public class ControllerUiButtonSettings : ControllerCanvasButtons
{
   private CanvasUi _canvasUi;
   private ControllerOpenCloseSettingCanvas _controllerOpenCloseSettingCanvas;
   private SoundSystem _soundSystem;
   [SerializeField] private SoundsUiDataSO _soundsUiDataSo;

   [SerializeField] private UiToggle _soundToggle, _vibrationToggle;

   private ManagerSave _managerSave;
   private void Awake()
   {
      _canvasUi = GetComponent<CanvasUi>();
      _controllerOpenCloseSettingCanvas = GetComponent<ControllerOpenCloseSettingCanvas>();
   }

   private void Start()
   {
      _managerSave = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>();
      _soundToggle.SetUiToggleVisual(_managerSave.SaveSystem.SaveState.IsSoundOn);
      _vibrationToggle.SetUiToggleVisual(_managerSave.SaveSystem.SaveState.IsVibrationOn );
      _soundSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSound>().SoundSystem;
   }

   public void SoundToggleButtonFunction()
   {
      _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.ButtonToggleSFX, 1);
      
      bool isSoundOn = _managerSave.SaveSystem.SaveState.IsSoundOn;
      
      _managerSave.SaveSystem.SaveState.IsSoundOn = !isSoundOn;
      _managerSave.SaveSystem.Save();
      
      _soundToggle.SetUiToggleVisual(_managerSave.SaveSystem.SaveState.IsSoundOn );
   }

   public void VibrationToggleButtonFunction()
   {
      _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.ButtonToggleSFX, 1);  
      
      bool isVibrationOn =_managerSave.SaveSystem.SaveState.IsVibrationOn;
      
      _managerSave.SaveSystem.SaveState.IsVibrationOn = !isVibrationOn;
      _managerSave.SaveSystem.Save();
      
      _vibrationToggle.SetUiToggleVisual(_managerSave.SaveSystem.SaveState.IsVibrationOn);
   }

   public void ExitButtonFunction()
   {
      if (_controllerOpenCloseSettingCanvas)
      {
         _controllerOpenCloseSettingCanvas.CloseUiCanvas(_canvasUi.CanvasUiParts);
         var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
         managerGame.SetCurrentGameStateType(GameStateType.LevelOpened);
         
         _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.ButtonExitSFX, 1);
      }
   }

   public void PrivacyPolicyButtonFunction()
   {
      Application.OpenURL("http://toliangames.com/privacy-policy/");
   }
}

}
