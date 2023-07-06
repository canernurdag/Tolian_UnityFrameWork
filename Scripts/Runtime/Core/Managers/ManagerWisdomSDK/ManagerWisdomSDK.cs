using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Systems.EventDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    public class ManagerWisdomSDK : MonoBehaviourService
    {
        protected override void Awake()
        {
            base.Awake();

            // // Subscribe
            //  SupersonicWisdom.Api.AddOnReadyListener(OnSupersonicWisdomReady);
            //  // Then initialize
            //  SupersonicWisdom.Api.Initialize();
        }

        private void Start()
        {
           // ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>().EventSystem.GetEvent<OnGameStateChange>().AddListener(NotifyLevelStarted);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            // ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>().EventSystem.GetEvent<OnGameStateChange>().RemoveListener(NotifyLevelStarted);
        }


        private void OnSupersonicWisdomReady()
        {
            //  ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerLevel>().OpenTheSameLevel(true);
        }

        public void NotifyLevelFailed()
        {
            //------------------SUPERSONIC WISDOM SDK---------------
            // SupersonicWisdom.Api.NotifyLevelFailed(ManagerSave.Instance.SaveState.LevelCounter, null);
        }

        public void NotifyLevelCompleted()
        {
            //------------------SUPERSONIC WISDOM SDK---------------
            // SupersonicWisdom.Api.NotifyLevelCompleted(ManagerSave.Instance.SaveState.LevelCounter, null);
        }

        private void NotifyLevelStarted(GameStateType gameStateType)
        {
            if (gameStateType == GameStateType.LevelOpened)
            {
                //----------- SUPERSONIC WISDOM SDK-------------
                // SupersonicWisdom.Api.NotifyLevelStarted(ManagerSave.Instance.SaveState.LevelCounter, null);
            }
        
        }
    }
}


