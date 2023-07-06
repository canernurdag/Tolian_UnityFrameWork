using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Systems.EventDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class controls opening and closing canvases via "UiCanvasSystem"
    /// </summary>
    [RequireComponent(typeof(UiCanvasSystem))]
    public class ControllerUiCanvases : MonoBehaviour
    {
        #region REFERENCES
        private ManagerEvent _managerEvent;
        public UiCanvasSystem UiCanvasSystem { get; private set; }
        #endregion

        #region VARIABLES
        [SerializeField] protected List<CanvasType> _levelOpeningCanvases = new();
        #endregion


        private void Awake()
        {
            UiCanvasSystem = GetComponent<UiCanvasSystem>();
        }

        private void OnDisable()
        {
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().RemoveListener(SetCanvasesAccordingToGameState);   
        }

        private void Start()
        {
            _managerEvent =  ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>();
            _managerEvent.EventSystem.GetEvent<OnGameStateChange>().AddListener(SetCanvasesAccordingToGameState);   
        }

        public void SetCanvasesAccordingToGameState(GameStateType gameStateType)
        {
            if (gameStateType == GameStateType.LevelOpened)
            {
                UiCanvasSystem.SetActivenessOfAllCanvases(false);
                
                for (int i = 0; i < _levelOpeningCanvases.Count; i++)
                {   
                    UiCanvasSystem.SetActivenessOfSpecificCanvas(_levelOpeningCanvases[i],true);
                }
            }
            else if (gameStateType == GameStateType.LevelStarted)
            {
                UiCanvasSystem. SetActivenessOfSpecificCanvas(CanvasType.CanvasInGameButton,false);
            }
        }
    }

}
