using System;
using System.Linq;
using Tolian.Runtime.Core.Managers;
using UnityEngine;

namespace Tolian.Runtime.Systems.OnboardingSystem
{
    public abstract class OnBoardingTask : MonoBehaviour
    {
        public bool IsTaskCompleted = false;
        public OnboardingStep OnboardingStep { get; protected set; }
    
        private ManagerSave _managerSave;
    
        private void Awake()
        {
            OnboardingStep = GetComponentInParent<OnboardingStep>(true);
        }
    
        private void Start()
        {
            _managerSave = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>();
        }
    
        public abstract void StartTask();
    
        public  void CompleteTask()
        {
            IsTaskCompleted = true;
            CompleteTaskInternal(() =>
            {
                int taskIndex = transform.GetSiblingIndex();
                if (taskIndex == OnboardingStep.OnBoardingTasks.Count - 1)
                {
                    try
                    {
                        if (_managerSave.SaveSystem.SaveState.OnboardingStepsCompletionSituations
                            .Any(x => x.Id == OnboardingStep.UniqueId))
                        {
                            var data = _managerSave.SaveSystem.SaveState.OnboardingStepsCompletionSituations
                                .First(x => x.Id == OnboardingStep.UniqueId);
                            data.IsCompleted = true;
                            _managerSave.SaveSystem.Save();
                        }
                       
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        throw;
                    } 
                }
                else
                {
                    var nextTask = OnboardingStep.OnBoardingTasks[taskIndex + 1];
                    nextTask.StartTask();
                }
            });
    
        }
    
        protected abstract void CompleteTaskInternal(Action nextTaskCallback);
    }
}

