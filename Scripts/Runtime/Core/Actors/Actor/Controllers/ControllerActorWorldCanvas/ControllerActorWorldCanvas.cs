using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tolian.Runtime.Core.Actors.Controllers.WorldCanvasSystem
{
    /// <summary>
    /// Base class for WorldCanvasControllers
    /// </summary>
    public abstract class ControllerActorWorldCanvas : MonoBehaviour
    {
        #region REFERENCES
        [SerializeField] protected TMP_Text _tmpText;
        [SerializeField] protected Slider _slider; 
        #endregion

        #region INTERNAL VARIABLES
        protected Tween _sliderTween;
        #endregion

        public void SetTMPText(string value)
        {
            _tmpText.text = value;
        }

        public void SetSliderValue(float value)
        {
            _slider.value = value;
        }
        
        public void SetSliderValue(float value, float duration)
        {
            _sliderTween?.Kill();
            _sliderTween = _slider.DOValue(value, duration);
        }

        public void SetSliderValue(float value, float duration, Action callback)
        {
            _sliderTween?.Kill();
            _sliderTween = _slider.DOValue(value, duration)
                .OnComplete(()=>callback());
        }

    }

}
