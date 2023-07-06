using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Core.UiSystem;
using Tolian.Runtime.Systems.EventDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class handles basic-tutorials which can be observed in Ui in the beginning of levels.
    /// </summary>
    public class ControllerUiTutorialCanvas : MonoBehaviour
    {
        private List<UiTutorial> _uiTutorials = new List<UiTutorial>();
        [SerializeField] private UiTutorialType activeUiTutorial;
        private ManagerEvent _managerEvent;
        private void Awake()
        {
            _uiTutorials = GetComponentsInChildren<UiTutorial>(true).ToList();
        }
        
        private void OnEnable()
        {
            _managerEvent = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>();
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().AddListener(SetUiTutorialObjectActivenessByGameState);
        }
    
        private void OnDisable()
        {
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().RemoveListener(SetUiTutorialObjectActivenessByGameState);
        }
    
        private void SetUiTutorialObjectActivenessByGameState(GameStateType gameStateType)
        {
            if (gameStateType == GameStateType.LevelOpened)
            {
                SetActivenessOfAllTutorialObjects(false);
                SetActivenessOfSpecificTutorialObject(activeUiTutorial, true);
            }
            else if (gameStateType == GameStateType.LevelStarted)
            {
                SetActivenessOfAllTutorialObjects(false);
            }
        }
    
        private void SetActivenessOfAllTutorialObjects(bool value)
        {
            for (int i = 0; i < _uiTutorials.Count; i++)
            {
                _uiTutorials[i].gameObject.SetActive(value);
            }
        }
    
        public void SetActivenessOfSpecificTutorialObject(UiTutorialType uiTutorialType, bool value)
        {
            if (uiTutorialType != UiTutorialType.None)
            {
                var activeTutorial =  _uiTutorials.First(x=>x.UiTutorialType == activeUiTutorial);
                if (activeTutorial)
                {
                    activeTutorial.gameObject.SetActive(value);
                }
            }
        }
    }
}
