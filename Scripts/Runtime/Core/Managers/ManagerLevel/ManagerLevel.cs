using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Core.Managers.LevelSystem;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tolian.Runtime.Core.Managers
{
    /// <summary>
    /// This class controls level transactions with Unity's SceneManagement.
    /// This classes can be extended with "Addressables" and "Additive Scenes" according to needs
    /// </summary>
    public class ManagerLevel : MonoBehaviourService
    {
        public List<Level> Levels = new List<Level>();

        #region REFERENCES
        private ManagerSave _managerSave;
        private ManagerUi _managerUi;

        #endregion

        private void Start()
        {
            _managerSave = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>();
            _managerUi = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>();
        }

        public void OpenTheSameLevel(bool isAsync)
        {
            ExecuteLevelOpening(isAsync, _managerSave.SaveSystem.SaveState.LastLevelIndex);
        }
        
        /// <summary>
        /// This function can be called to open the next level.
        /// </summary>
        /// <param name="isAsync"></param>
        public void OpenNextLevelScene(bool isAsync) 
        {
            if(_managerSave.SaveSystem.SaveState.LastLevelIndex == Levels.Count-1)
            {
                _managerSave.SaveSystem.SaveState.LastLevelIndex = GetNextReturningLevelFromStartingLevelZero().LevelIndex;
            }
            else 
            {
                _managerSave.SaveSystem.SaveState.LastLevelIndex++;
            }
            _managerSave.SaveSystem.SaveState.LevelCounter++;
            _managerSave.SaveSystem.Save();

            ExecuteLevelOpening(isAsync, _managerSave.SaveSystem.SaveState.LastLevelIndex);
       
        }

        /// <summary>
        /// The main function that handles level changing process
        /// </summary>
        /// <param name="isAsync"></param>
        /// <param name="levelIndex"></param>
        private void ExecuteLevelOpening(bool isAsync, int levelIndex)
        {
            if (isAsync)
            {
                StartCoroutine(OpenLevelAsync(levelIndex));
            }
            else if (!isAsync)
            {
                OpenLevelSync(levelIndex);
            }
        }
        
        private void OpenLevelSync(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
            
            var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>( );
            managerGame.SetCurrentGameStateType(GameStateType.LevelOpened);
            
        }

        private IEnumerator OpenLevelAsync(int levelIndex)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(levelIndex);
            
            _managerUi.ControllerUiCanvases.UiCanvasSystem.SetActivenessOfAllCanvases(false);
            _managerUi.ControllerUiCanvases.UiCanvasSystem.SetActivenessOfSpecificCanvas(CanvasType.CanvasLoading,true);        
            
            var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
            managerGame.SetCurrentGameStateType(GameStateType.Loading);

            while (!loadSceneAsync.isDone)
            {
                _managerUi.ControllerUiLoadingCanvas.SetSliderValue(loadSceneAsync.progress);
                yield return null;
            }
            
            managerGame.SetCurrentGameStateType(GameStateType.LevelOpened);
        }
        
        private Level GetNextReturningLevelFromStartingLevelZero()
        {
            try
            {
                for (int i = 0; i < Levels.Count; i++)
                {
                    if (Levels[i].IsLevelReturnable)
                    {
                        return Levels[i];
                    }
                }

                throw new Exception();
            }
            catch
            {
                return null;
            }
          
        }
        
    }
}


