using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Systems.EventDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    public sealed class ManagerGame : MonoBehaviourService
    {
        /// <summary>
        /// The one of the most important variable in the system. The most logics depends on this.
        /// </summary>
        private GameStateType _currentGameStateType;
        public GameStateType CurrentGameStateType => _currentGameStateType;
    
        protected override void Awake()
        {
            base.Awake();
            SetQualityAndFPS();
        }

        /// <summary>
        /// This function can be extended by giving specific values according to target platform.
        /// Besides, this function can be linked to "Ui Settings" and Save System
        /// </summary>
        private void SetQualityAndFPS()
        {
#if UNITY_ANDROID || UNITY_IOS
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
#endif
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }
        
        /// <summary>
        /// Set the CurrentGameStateType here. In addition, this function rises "OnGameStateChange" event to notify all systems in the games.
        /// </summary>
        /// <param name="gameStateType"></param>
        public void SetCurrentGameStateType(GameStateType gameStateType)
        {
            _currentGameStateType = gameStateType;
            ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerEvent>().EventSystem.GetEvent<OnGameStateChange>().Execute(gameStateType);
        }
    }
    
}

