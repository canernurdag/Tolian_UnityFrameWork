using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseLoadingCanvas : ControllerCanvasOpenCloseBase
    {
        public override void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
       
        }

        public override void CloseUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            gameObject.SetActive(false);
        }
    }

}

