using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseMoneyCanvas : ControllerCanvasOpenCloseBase
    {
        public override void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            for (int i = 0; i < canvasUiParts.Count; i++)
            {
                CanvasUiPart canvasUiPart = canvasUiParts[i];
                int no = i;
                canvasUiPart.SetScale(Vector3.zero);
            
                DOVirtual.DelayedCall(no * _durationBetweenCanvasUiParts, () =>
                {
                    canvasUiPart.SetScale(Vector3.one, 0.3f);
                });

            }
        }

        public override void CloseUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            for (int i = 0; i < canvasUiParts.Count; i++)
            {
                CanvasUiPart canvasUiPart = canvasUiParts[i];
                int no = i;
            
                DOVirtual.DelayedCall(no * _durationBetweenCanvasUiParts, () =>
                {
                    canvasUiPart.SetScale(Vector3.zero, 0.3f);
                    if (no == canvasUiParts.Count - 1)
                    {
                        gameObject.SetActive(false);
                    }
                });

            }
        }
    }
}


