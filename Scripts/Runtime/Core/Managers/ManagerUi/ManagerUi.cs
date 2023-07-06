using Tolian.Runtime.Core.Managers.UiSystem;
using Tolian.Runtime.Systems.ServiceLocatorDomain;

namespace Tolian.Runtime.Core.Managers
{
/// <summary>
/// This is the main class that includes all ui control classes, except for "World Space Canvases".
/// </summary>
    public class ManagerUi : MonoBehaviourService
    {
        #region REFERENCES
        public ControllerUiCanvases ControllerUiCanvases { get; protected set; }
        public ControllerUiJoystickCanvas ControllerUiJoystickCanvas { get; protected set; }
        public ControllerUiLevelCanvas ControllerUiLevelCanvas { get; protected set; }
        public ControllerUiTutorialCanvas ControllerUiTutorialCanvas { get; protected set; }
        public ControllerUiPointerCanvas ControllerUiPointerCanvas { get; protected set; }
        public ControllerUiMoneyCanvas ControllerUiMoneyCanvas { get; protected set; }
        public ControllerUiLoadingCanvas ControllerUiLoadingCanvas { get; protected set; }
        #endregion
        
        protected override void Awake()
        {
            base.Awake();

            ControllerUiCanvases = GetComponent<ControllerUiCanvases>();
            ControllerUiJoystickCanvas = GetComponent<ControllerUiJoystickCanvas>();
            ControllerUiLevelCanvas = GetComponent<ControllerUiLevelCanvas>();
            ControllerUiTutorialCanvas = GetComponent<ControllerUiTutorialCanvas>();
            ControllerUiPointerCanvas = GetComponent<ControllerUiPointerCanvas>();
            ControllerUiMoneyCanvas = GetComponent<ControllerUiMoneyCanvas>();
            ControllerUiLoadingCanvas = GetComponent<ControllerUiLoadingCanvas>();
        }
        
    }
}


