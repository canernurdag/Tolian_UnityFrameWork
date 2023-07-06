using System.Collections;
using System.Collections.Generic;
using Tolian.Runtime.Systems.UiDomain;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseBaseDamageCanvas : ControllerCanvasOpenCloseBase
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
