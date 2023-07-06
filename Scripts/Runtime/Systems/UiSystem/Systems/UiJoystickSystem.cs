using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tolian.Runtime.Systems.UiDomain
{
    public class UiJoystickSystem : MonoBehaviour
    {
        public Vector2 GetAnchoredPositionFromScreenPoint(Vector2 screenPosition, RectTransform panelRectTransform, RectTransform joystickImageBackground )
        {
            Vector2 localPoint = Vector2.zero;
           
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, screenPosition, 
                    null, out localPoint))
            {
                Vector2 pivotOffset = panelRectTransform.pivot * panelRectTransform.sizeDelta;
                return localPoint - (joystickImageBackground.anchorMax * panelRectTransform.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
    }

}
