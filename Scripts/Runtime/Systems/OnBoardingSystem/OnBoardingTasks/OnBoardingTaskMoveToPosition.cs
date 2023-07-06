using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Systems.OnboardingSystem
{
    public class OnBoardingTaskMoveToPosition : OnBoardingTask
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private LineRenderer _lineRenderer;
    
        public override void StartTask()
        {
            _lineRenderer.gameObject.SetActive(true);
        }
    
        protected override void CompleteTaskInternal(Action nextTaskCallback)
        {
            _lineRenderer.gameObject.SetActive(false);
            nextTaskCallback();
        }

        private void Update()
        {
            if(!_lineRenderer.gameObject.activeInHierarchy) return;
        
            // _lineRenderer.SetPosition(0, PlayerTransform);
            _lineRenderer.SetPosition(1, _targetTransform.position);   
        }

   
    }

}
