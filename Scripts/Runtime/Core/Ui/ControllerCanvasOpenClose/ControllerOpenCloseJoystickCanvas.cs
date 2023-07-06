using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseJoystickCanvas : ControllerCanvasOpenCloseBase
    {
        public void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
       
        }

        public void CloseUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            gameObject.SetActive(false);
        }
    }
}

