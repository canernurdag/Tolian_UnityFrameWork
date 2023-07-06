using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class UiToggle : MonoBehaviour
    {
        [SerializeField] private GameObject _openVisual, _closeVisual;

        public void SetUiToggleVisual(bool isOpen)
        {
            _openVisual.SetActive(isOpen);
            _closeVisual.SetActive(!isOpen);
        }
    }
    
}
