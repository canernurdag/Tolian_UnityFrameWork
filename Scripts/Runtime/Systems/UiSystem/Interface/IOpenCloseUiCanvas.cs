using System.Collections.Generic;

namespace Tolian.Runtime.Systems.UiDomain
{
    public interface IOpenCloseUiCanvas
    {
        void OpenUiCanvas(List<CanvasUiPart> canvasUiParts);
        void CloseUiCanvas(List<CanvasUiPart> canvasUiParts);

    }
}

