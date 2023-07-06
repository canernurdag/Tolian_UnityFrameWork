using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tolian.Runtime.Systems.UiDomain
{
    /// <summary>
    /// Each Canvas objects, except for World Canvases, represented by this class.
    /// New canvases can be added by adding a new enum to CanvasType.
    /// </summary>
    public class CanvasUi : MonoBehaviour
    {
        public CanvasType CanvasType;
        public IOpenCloseUiCanvas OpenCloseUiCanvas { get; private set; }
        public List<CanvasUiPart> CanvasUiParts { get; private set; }
   

        private void Awake()
        {
            CanvasUiParts = GetComponentsInChildren<CanvasUiPart>(true).ToList();
            OpenCloseUiCanvas = GetComponent<IOpenCloseUiCanvas>();
        }

        public void SetCanvasActiveness(bool activenessValue)
        {
            if (activenessValue)
            {
                OpenCloseUiCanvas.OpenUiCanvas(CanvasUiParts);
            }
            else if (!activenessValue)
            {
                OpenCloseUiCanvas.CloseUiCanvas(CanvasUiParts);
            }
        }
   
    }
}

