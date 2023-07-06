using Tolian.Runtime.Core.ScriptableObjects.Data;
using Tolian.Runtime.Systems.InputDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Actors.Controllers.ControlSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class ControllerBaseControllerControllerBasePlayerJoystick : ControllerControllerBasePlayer
    {
        #region References
        public Rigidbody Rigidbody { get; protected set; }
        [SerializeField] private PlayerDataSO playerDataSo;
        #endregion
    
        #region Init Variables Rotation
        private Quaternion _currentRot;
        private Vector3 _targetRotAngle;
        #endregion
        
        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    
        private void FixedUpdate()
        {
            if(_preventControl) return;
            
    #if UNITY_EDITOR
            if(!Input.GetMouseButton(0)) return;
    #endif
            
            ControllerLogic();
        }
    
        protected override void ControllerLogic()
        {
            CharacterMovement();
            CharacterRotation();
        }
    
        private void CharacterMovement()
        {
            Rigidbody.AddForce(new Vector3(InputSystem.DeltaInputVector.x* playerDataSo.MovementMultiplier,
               0, 
               InputSystem.DeltaInputVector.y* playerDataSo.MovementMultiplier));
        }
    
        private void CharacterRotation()
        {
            _currentRot = transform.rotation;
            _targetRotAngle = new Vector3(InputSystem.DeltaInputVector.x, Rigidbody.velocity.y, InputSystem.DeltaInputVector.y)
                .normalized;
            if (_targetRotAngle == Vector3.zero) _targetRotAngle = new Vector3(0, 0.001f, 0);
            Quaternion lookRotation = Quaternion.LookRotation(_targetRotAngle, Vector3.up);
            lookRotation.x = 0f;
            lookRotation.z = 0f;
            transform.rotation = Quaternion.Lerp(_currentRot, lookRotation,
                Time.fixedDeltaTime * playerDataSo.RotationMultiplier);
        }
        
        public void ResetRigidbody()
        {
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
        }
    }
}


