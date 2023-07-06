using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseSettingCanvas : ControllerCanvasOpenCloseBase
    {
        [SerializeField] private GameObject _popParent;
        private Tween _popParentScaleTween;
        
        public override void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            for (int i = 0; i < canvasUiParts.Count; i++)
            {
                CanvasUiPart canvasUiPart = canvasUiParts[i];
                canvasUiPart.SetScale(Vector3.zero);
            }

            _popParent.transform.localScale = Vector3.zero;
            _popParentScaleTween?.Kill();
            _popParentScaleTween = _popParent.transform.DOScale(Vector3.one, 0.3f)
               .OnComplete(() =>
               {
                   for (int i = 0; i < canvasUiParts.Count; i++)
                   {
                       CanvasUiPart canvasUiPart = canvasUiParts[i];
                       int no = i;
                    
                       DOVirtual.DelayedCall(no * _durationBetweenCanvasUiParts, () =>
                       {
                           canvasUiPart.SetScale(Vector3.one, 0.3f);
                       });

                   }
               });
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
                        _popParentScaleTween?.Kill();
                        _popParentScaleTween = _popParent.transform.DOScale(Vector3.zero, 0.3f)
                            .OnComplete(() =>
                            {
                                gameObject.SetActive(false);
                            });
                    }
                });

            }
        }
    }
}


