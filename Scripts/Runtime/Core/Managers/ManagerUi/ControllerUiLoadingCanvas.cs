using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    public class ControllerUiLoadingCanvas : MonoBehaviour
    {
        [SerializeField] private Slider _loadingSlider;
        [SerializeField] private TMP_Text _loadingText;

        public void SetSliderValue(float value)
        {
            value = Mathf.Clamp01(value);
            _loadingSlider.value = value;
            _loadingText.text = $"{value * 100}%";
        }
    
    }
}


