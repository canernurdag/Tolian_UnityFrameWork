using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Core.Managers;
using UnityEngine;

namespace Tolian.Runtime.Systems.OnboardingSystem
{
 
   /// <summary>
   /// This system is on progress. Please do not use it yet.
   /// </summary>
   public class ControllerOnBoarding : MonoBehaviour
   {
      public List<OnboardingStep> OnboardingSteps = new List<OnboardingStep>();
   
      private void Awake()
      {
         OnboardingSteps = GetComponentsInChildren<OnboardingStep>(true).ToList();
      }
   
      private void Start()
      {
         for (int i = 0; i < OnboardingSteps.Count; i++)
         {
            OnboardingSteps[i].AddThisStepToSaveSystemIfNotExistInSaveSystem();
         }
      }
   
      public void StartNextUncompletedOnBoardingStep()
      {
         List<int> ids = new List<int>();
         for (int i = 0; i < OnboardingSteps.Count; i++)
         {
            ids.Add(OnboardingSteps[i].UniqueId);
         }
   
         var datasOfTheController = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>().SaveSystem.SaveState.OnboardingStepsCompletionSituations
            .Where(x => ids.Contains(x.Id)).ToList();
   
         if (datasOfTheController.Any(x => !x.IsCompleted))
         {
            var firstUncompletedStep = datasOfTheController
               .First(x => !x.IsCompleted);
   
            if (OnboardingSteps.Any(x => x.UniqueId == firstUncompletedStep.Id))
            {
               var onboardingStep = OnboardingSteps.First(x => x.UniqueId == firstUncompletedStep.Id);
               onboardingStep.GetNextUncompletedOnBoardingTask().StartTask();
            }
            else
            {
               return;
            }
          
         }
         else
         {
            return;
         }
      }
   }
}

