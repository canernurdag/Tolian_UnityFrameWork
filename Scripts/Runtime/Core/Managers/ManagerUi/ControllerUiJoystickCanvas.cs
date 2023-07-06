using Tolian.Runtime.Systems.InputDomain;
using Tolian.Runtime.Systems.ServiceLocatorDomain;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class controls Ui Joystick via "UiJoystickSystem"
    /// </summary>
    [RequireComponent(typeof(UiJoystickSystem))]
    public class ControllerUiJoystickCanvas : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        #region REFERENCES
        public UiJoystickSystem UiJoystickSystem { get; private set; }
        private ManagerInput _managerInput;

        [SerializeField] private RectTransform _joystickImageBackground = null;
        [SerializeField] private RectTransform _joystickImageHandle = null;
        [SerializeField] private RectTransform _panelRecttransform;
        [SerializeField] private Canvas _joystickCanvas;
        #endregion

        #region Internal variables
        private JoystickType _activeJoystickType;
        [SerializeField] private float _deadZone = 0;
        [SerializeField] private float _handleRange = 1;
        private Vector2 _joystickImageBackgroundRadiusVector;
        #endregion

        #region Output
        private Vector2 _joystickInputVector;
        #endregion

        #region Dynamic Joystick
        [Header("Dynamic Joystick")]
        [SerializeField] private float _moveTreshold = 1;
        #endregion
        
        private void Start()
       { 
           //REFERENCES
           _managerInput = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerInput>();
           UiJoystickSystem = GetComponent<UiJoystickSystem>();
           
          Vector2 center = new Vector2(0.5f, 0.5f);
          _joystickImageBackground.pivot = center;
          _joystickImageHandle.pivot = center;
          _joystickImageHandle.anchorMin = center;
          _joystickImageHandle.anchorMax = center;

          _joystickImageBackgroundRadiusVector = _joystickImageBackground.sizeDelta / 2;
          
       }

        
       public void OnPointerDown(PointerEventData eventData)
       {
           switch (_activeJoystickType)
           {
               case JoystickType.Static:
                   break;
               case JoystickType.Floating:
                   _joystickImageBackground.anchoredPosition = UiJoystickSystem.GetAnchoredPositionFromScreenPoint(eventData.position, _panelRecttransform, _joystickImageBackground);
                   _joystickImageBackground.gameObject.SetActive(true);
                   break;
               case JoystickType.Dynamic:
                   _joystickImageBackground.anchoredPosition = UiJoystickSystem.GetAnchoredPositionFromScreenPoint(eventData.position, _panelRecttransform, _joystickImageBackground);
                   _joystickImageBackground.gameObject.SetActive(true);
                   break;
           }
           OnDrag(eventData);
       }

       /// <summary>
       /// This function sets ManagerInput's DeltaVector when Joystick is selected as Input Provider
       /// </summary>
       /// <param name="eventData"></param>
       public void OnDrag(PointerEventData eventData)
       {
           Vector2 screenPositionOfJoystickImageBackground = RectTransformUtility.WorldToScreenPoint(null, _joystickImageBackground.position);
           _joystickInputVector = (eventData.position - screenPositionOfJoystickImageBackground) / (_joystickImageBackgroundRadiusVector* _joystickCanvas.scaleFactor);
           HandleInput(_joystickInputVector);
           _joystickImageHandle.anchoredPosition = _joystickInputVector * _joystickImageBackgroundRadiusVector * _handleRange;
           
           _managerInput.InputSystem.SetDeltaInputVector(_joystickInputVector);
       }

       public void OnPointerUp(PointerEventData eventData)
       {
           switch (_activeJoystickType)
           {
               case JoystickType.Static:
                   break;
               case JoystickType.Floating:
                   _joystickImageBackground.gameObject.SetActive(false);
                   break;
               case JoystickType.Dynamic:
                   _joystickImageBackground.gameObject.SetActive(false);
                   break;
           }
           
          _joystickInputVector = Vector2.zero;
          _joystickImageHandle.anchoredPosition = Vector2.zero;
          
          _managerInput.InputSystem.SetDeltaInputVector(_joystickInputVector);
       }


       private void HandleInput(Vector2 input)
       {
           switch (_activeJoystickType)
           {
               case JoystickType.Static:
                   break;
               case JoystickType.Floating:
                   break;
               
               case JoystickType.Dynamic:
                   if (input.magnitude > _moveTreshold)
                   {
                       Vector2 differenceVector = input.normalized * (input.magnitude - _moveTreshold) *
                                            _joystickImageBackgroundRadiusVector;
                       _joystickImageBackground.anchoredPosition += differenceVector;
                   }
                   break;
           }
           
           if (input.magnitude > _deadZone)
           {
               if (input.magnitude > 1) _joystickInputVector = input.normalized;
               else _joystickInputVector = input;
           }
           else 
               _joystickInputVector = Vector2.zero;
       }

       #region Set Functions
       public void SetActiveJoystick(JoystickType targetJoystickType)
       {
           _activeJoystickType = targetJoystickType;

           switch (_activeJoystickType)
           {
               case JoystickType.Static:
                   break;
               case JoystickType.Floating:
                   _joystickImageBackground.gameObject.SetActive(false);
                   break;
               case JoystickType.Dynamic:
                   _joystickImageBackground.gameObject.SetActive(false);
                   break;
           }
       }
       #endregion
       
    }
}

