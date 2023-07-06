using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Helpers
{
    public class Undestroyable : MonoBehaviour
    {
        #region Fields
        [SerializeField] private bool _isUndestroyable;
        #endregion

        #region Properties
        public bool IsUndestroyable => _isUndestroyable;
        #endregion

        private void Awake()
        {
            if (IsUndestroyable)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}

