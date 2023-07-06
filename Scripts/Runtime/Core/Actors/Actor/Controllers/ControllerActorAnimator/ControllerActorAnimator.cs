using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Tolian.Runtime.Core.Actors.Controllers.AnimatorSystem
{
    /// <summary>
    /// Base class for AnimatorControllers
    /// </summary>
    public abstract class ControllerActorAnimator : MonoBehaviour
    {
        protected Tween _parameterTween;
        protected Tween _layerTween;
        
        /// <summary>
        /// Reference of Animator class
        /// </summary>
        [SerializeField] protected Animator _animator;

        #region Set Functions

        public virtual void SetAnimatorActiveness(bool value)
        {
            _animator.enabled = value;
        }

        public virtual void SetCurrentAnimatorStateAndPlayImmediately(string stateName, int layerNo, float normalizedTime)
        {
            _animator.Play(stateName,layerNo,normalizedTime);
        }
        
        public virtual void SetCurrentAnimatorState(string stateName)
        {
            _animator.SetTrigger(stateName);
        }
        public virtual void SetCurrentAnimatorState(string stateName, bool boolValue)
        {
            _animator.SetBool(stateName, boolValue);
        }
    
        public virtual void SetAnimatorLayerWeight(int layerIndex, float layerWeight)
        {
            _animator.SetLayerWeight(layerIndex, layerWeight);
        }
    
        public virtual void SetAnimatorLayerWeight(int layerIndex, float layerWeight, float duration)
        {
            _layerTween?.Kill();
            _layerTween = DOTween.To(() => _animator.GetLayerWeight(layerIndex), x => _animator.SetLayerWeight(layerIndex, x), layerWeight,
                duration);
        }

        public virtual void SetFloatParameter(string floatName, float value)
        {
            _animator.SetFloat(floatName, value);
        }

        public virtual void SetFloatParameter(string floatName, float value, float duration)
        {
            _parameterTween?.Kill();
            _parameterTween = DOTween.To(() => _animator.GetFloat(floatName), x => _animator.SetFloat(floatName, x), value, duration);
        }

        #endregion
  
    }
}

