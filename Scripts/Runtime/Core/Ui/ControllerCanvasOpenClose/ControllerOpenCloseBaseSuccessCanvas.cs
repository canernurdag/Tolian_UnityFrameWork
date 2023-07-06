using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Systems.SoundDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerOpenCloseBaseSuccessCanvas : ControllerCanvasOpenCloseBase
    {
      
        private SoundSystem _soundSystem;
        private void Start()
        {
            _soundSystem = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerSound>().SoundSystem;
        }
        public override void OpenUiCanvas(List<CanvasUiPart> canvasUiParts)
        {
            for (int i = 0; i < canvasUiParts.Count; i++)
            {
                CanvasUiPart canvasUiPart = canvasUiParts[i];
                int no = i;
                canvasUiPart.SetScale(Vector3.zero);

                UiStar uiStar = canvasUiPart.GetComponent<UiStar>();
                if (uiStar)
                {
                    int index = uiStar.transform.GetSiblingIndex();
                    DOVirtual.DelayedCall(index * _durationBetweenCanvasUiParts, () =>
                    {
                        canvasUiPart.SetScale(Vector3.one, 0.3f, () =>
                        {
                            _soundSystem.PlaySoundAtPoint(Vector3.zero, _soundsUiDataSo.StarSFX, 1);
                            if (uiStar.ParticleSystems.Count > 0)
                            {
                                for (int j = 0; j <uiStar.ParticleSystems.Count; j++)
                                {
                                    uiStar.ParticleSystems[j].Play();
                                }
                            }
                        });
                    });
                }
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


