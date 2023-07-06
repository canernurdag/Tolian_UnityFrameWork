using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Systems.CinemachineDomain
{
    public class GhostObjectForCinemachineTarget : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        private void LateUpdate()
        {
            if (_targetTransform)
            {
                transform.position = _targetTransform.transform.position;
            }
        }
    }
}

