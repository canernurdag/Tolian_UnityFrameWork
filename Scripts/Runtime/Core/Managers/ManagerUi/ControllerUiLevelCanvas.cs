using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class controls Ui objects such as levelNo, levelProgress etc which reflects data related to current level
    /// </summary>
    public class ControllerUiLevelCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private Slider _fillSlider;
        private Tween _fillTween; 

        private void SetLevelId()
        {
            _level.text = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSave>().SaveSystem.SaveState.LevelCounter.ToString();
        }

        public void SetLevelProgress(float value, float duration)
        {
            _fillTween?.Kill();
            _fillTween = DOTween.To(() => _fillSlider.value,
                x => _fillSlider.value = x,
                value,
                duration);
        }

        public void SetLevelProgress(float value)
        {
            _fillSlider.value = value;
        }
    }
}

