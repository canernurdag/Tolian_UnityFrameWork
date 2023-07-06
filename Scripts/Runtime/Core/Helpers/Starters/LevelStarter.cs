using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.Enums;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelStarter : MonoBehaviour
{
    #region REFERENCES
    public ManagerGame ManagerGame { get; private set; }
    
    #endregion
    
    #region Variables
    [SerializeField] private LevelStarterType _levelStarterType;

    private const string UITARGETTAG = "InGameButton"; //Declare and def
    #endregion
    
    private void Start()
    {
        ManagerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
        
        switch (_levelStarterType)
        {
            case LevelStarterType.StartWithinFirstFrame:
                ManagerGame.SetCurrentGameStateType(GameStateType.LevelStarted);
                break;
            case LevelStarterType.StartWithFirstInput:
                
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Update()
    {
        if (ManagerGame.CurrentGameStateType == GameStateType.LevelOpened)
        {
            if (Input.GetMouseButton(0) || Input.touchCount > 0)
            {
                if (!IsPointerOverTargetUiObject(UITARGETTAG))
                {
                    ManagerGame.SetCurrentGameStateType(GameStateType.LevelStarted);
                }
            }
        }
    }

    private bool IsPointerOverTargetUiObject(string targetGameObjectTag)
    {
        if (!EventSystem.current.IsPointerOverGameObject()) return false;
        if (EventSystem.current.currentSelectedGameObject == null) return false;
        if (EventSystem.current.currentSelectedGameObject.CompareTag(targetGameObjectTag)) return true;

        return false;
    }
}