using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Core.Actors.Controllers.ControlSystem
{
    public abstract class ControllerControllerBase : MonoBehaviour
    {
        #region Internals
        protected bool _preventControl;
        #endregion
        
        protected abstract void ControllerLogic();

        public virtual void SetPreventControl(bool value)
        {
            _preventControl = value;
        }
    } 
}

