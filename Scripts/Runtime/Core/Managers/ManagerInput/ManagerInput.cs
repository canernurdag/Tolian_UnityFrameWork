using Tolian.Runtime.Core.Managers.UiSystem;
using Tolian.Runtime.Systems.InputDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers
{
    [DefaultExecutionOrder(100)]
    [RequireComponent(typeof(InputSystem))]
    public class ManagerInput : MonoBehaviourService
    {
        #region REFERENCES
        public InputSystem InputSystem { get; private set; }
        public ControllerUiJoystickCanvas ControllerUiJoystickCanvas { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();
            
            //REFERENCES
            InputSystem = GetComponent<InputSystem>();
        }

        private void Start()
        {
            //REFERENCES
            ControllerUiJoystickCanvas = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>()
                .ControllerUiJoystickCanvas;
            
            if (InputSystem.InputType == InputType.Joystick)
            {
                switch (InputSystem.JoystickType)
                {
                    case JoystickType.Static:
                        ControllerUiJoystickCanvas.SetActiveJoystick(JoystickType.Static);
                            
                        break;

                    case JoystickType.Floating:
                        ControllerUiJoystickCanvas.SetActiveJoystick(JoystickType.Floating);
                            
                        break;
                        
                    case JoystickType.Dynamic:
                        ControllerUiJoystickCanvas.SetActiveJoystick(JoystickType.Dynamic);
                        break;
                }
                
            }
       
        }
        
    }

}

