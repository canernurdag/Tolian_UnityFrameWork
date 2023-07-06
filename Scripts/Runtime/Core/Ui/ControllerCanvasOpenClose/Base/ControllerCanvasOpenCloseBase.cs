using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    /// <summary>
    /// This class handles how the canvas should be opened and closed. Each canvas can have a unique behaviour by overriding functions.
    /// </summary>
    public class ControllerCanvasOpenCloseBase : MonoBehaviour, IOpenCloseUiCanvas
    {
        [SerializeField] protected SoundsUiDataSO _soundsUiDataSo;
        [SerializeField] protected float _durationBetweenCanvasUiParts = 0.15f;
        public virtual void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            
        }

        public virtual void CloseUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            
        }
    }
}
