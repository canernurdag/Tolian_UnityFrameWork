using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Tolian.Runtime.Systems.CinemachineDomain
{
    [RequireComponent(typeof(ControllerCinemachineCameraShake))]
    public class CinemachineSystem : MonoBehaviour
    {
        #region REFERENCES
        private Animator _cinemachineAnimator;
        public CinemachineStateDrivenCamera CinemachineStateDrivenCamera { get; private set; }
        public ControllerCinemachineCameraShake ControllerCinemachineCameraShake { get; private set; }
        #endregion
        
        protected  void Awake()
        {
            ControllerCinemachineCameraShake = GetComponent<ControllerCinemachineCameraShake>();
            CinemachineStateDrivenCamera = GetComponentInChildren<CinemachineStateDrivenCamera>();
            _cinemachineAnimator = GetComponentInChildren<Animator>();
        }

        /// <summary>
        /// In order to change the active virtual camera
        /// </summary>
        /// <param name="targetAnimationParameter"></param>
        public void SetActiveVcamByUsingAnimator(string targetAnimationParameter)
        {
            _cinemachineAnimator.SetTrigger(targetAnimationParameter);
        }

        public CinemachineVirtualCamera GetActiveVCAM()
        {
            return (CinemachineVirtualCamera)CinemachineStateDrivenCamera.LiveChild;
        }
    }

}
