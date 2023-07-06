using System;
using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.Interfaces;
using UnityEngine;

namespace Tolian.Runtime.Helpers
{
    public class UpdateFrameFrequencyController : MonoBehaviour
    {
        //Update start variables
        protected bool _isUpdateActive = false;
        protected int _startFrame = 0;
        [SerializeField] protected int _targetFrameRate = 60;
        
        //Update time check variables
        protected float _timer = 0;
        protected float _durationBetweenCalls = 0.5f;
    
        protected ISetUpdateFunction _iSetUpdateFunction;
    
        protected virtual void Awake()
        {
            _startFrame = UnityEngine.Random.Range(0, _targetFrameRate);
        }
    
        protected virtual IEnumerator Start()
        {
            int currentFrame = 0;
            
            while (!_isUpdateActive)
            {
                currentFrame++;
                
                if (currentFrame >= _startFrame)
                {
                    _isUpdateActive = true;
                    yield break;
                }
                
                yield return new WaitForEndOfFrame();
            }
        }
    
        protected virtual void Update()
        {
            if(!_isUpdateActive) return;
            
            if (_timer >= _durationBetweenCalls)
            {
                if (_iSetUpdateFunction != null)
                {
                    _iSetUpdateFunction.UpdateFunction();
                }
       
                _timer = 0;
            }
    
            _timer += Time.deltaTime;
        }
    
        public void SetDurationBetweenCalls(float targetValue)
        {
            _durationBetweenCalls = targetValue;
        }
    
        public void SetISetUpdateFunction(ISetUpdateFunction targetISetUpdateFunction)
        {
            _iSetUpdateFunction = targetISetUpdateFunction;
        }
    }
}
