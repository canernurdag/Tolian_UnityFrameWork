using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Systems.SaveDomain;

using UnityEngine;

namespace Tolian.Runtime.Systems.OnboardingSystem
{
    public class OnboardingStep : MonoBehaviour
    {
        public int UniqueId;
        public List<OnBoardingTask> OnBoardingTasks = new List<OnBoardingTask>();

        private ManagerSave _managerSave;
        private void Awake()
        {
            OnBoardingTasks = GetComponentsInChildren<OnBoardingTask>(true).ToList();
        }

        private void OnEnable()
        {
            _managerSave = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>();
        }

        public void AddThisStepToSaveSystemIfNotExistInSaveSystem()
        {
            OnboardingStepsCompletionSituation
                onboardingStepsCompletionSituation = new OnboardingStepsCompletionSituation();

            onboardingStepsCompletionSituation.Id = UniqueId;
            onboardingStepsCompletionSituation.IsCompleted = false;

            bool isSaveSystemContainsThisStep =
                _managerSave.SaveSystem.SaveState.OnboardingStepsCompletionSituations.Any(x => x.Id == UniqueId);
            if (!isSaveSystemContainsThisStep)
            {
                _managerSave.SaveSystem.SaveState.OnboardingStepsCompletionSituations.Add(onboardingStepsCompletionSituation);
            }
        }

        public OnBoardingTask GetNextUncompletedOnBoardingTask()
        {
            if (OnBoardingTasks.Any(x =>!x.IsTaskCompleted))
            {
                var onBoardingTask = OnBoardingTasks.First(x=> !x.IsTaskCompleted);
                return onBoardingTask;
            }

            return null;
        }
    }
    
}



