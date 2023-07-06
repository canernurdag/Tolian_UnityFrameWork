using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Helpers
{
    public class VisualGizmoAdder : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float _radius = 2;
        [SerializeField] private Color _color = Color.black;
        #endregion
    
        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}
