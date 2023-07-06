using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Systems.SaveDomain
{
    [System.Serializable]
    public class SaveState 
    {
        #region OnBoarding
        public List<OnboardingStepsCompletionSituation> OnboardingStepsCompletionSituations;
        #endregion
    
        #region LevelSettings
        public int LevelCounter;
        public int LastLevelIndex;
        #endregion

        #region PlayerSettings
        public int TotalMoneyAmount;
        public int CharacterIconListNo;
        public string PlayerName;
        #endregion
    
        #region Preferences
        public bool IsSoundOn;
        public bool IsVibrationOn;
        public bool IsNoAdsOn;
        #endregion
    
        public void SetInitialValues()
        {
            #region OnBoarding
            OnboardingStepsCompletionSituations = new List<OnboardingStepsCompletionSituation>();
            #endregion
        
            #region LevelSettings
            LastLevelIndex = 1;
            LevelCounter = 1;
            #endregion

            #region CharacterSettings
            TotalMoneyAmount = 0;
            CharacterIconListNo = 0;
            PlayerName = "Player";
            #endregion
        
            #region Preferences
            IsSoundOn = true;
            IsVibrationOn = true;
            IsNoAdsOn = false;
            #endregion
        }
    }

}
