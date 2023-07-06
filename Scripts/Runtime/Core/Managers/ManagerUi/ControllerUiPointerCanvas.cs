using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Tolian.Runtime.Core.UiSystem;
using UnityEngine;

namespace Tolian.Runtime.Core.Managers.UiSystem
{
    /// <summary>
    /// This class handles "Ui Pointers" which points to world space objects positions.
    /// </summary>
  public class ControllerUiPointerCanvas : MonoBehaviour
  {
      #region Cache
      private Transform _referenceTransform;
      private List<Transform> _targetTransformList = new List<Transform>();
      [SerializeField] private Canvas _parentCanvas;
      [SerializeField] private GameObject _uiPointerPrefabGameObect;
  
      #endregion
  
      #region Buffer
      private List<UiPointer> _uiPointerList = new List<UiPointer>();
      #endregion
          
      private void Start()
      {
          UpdateUiPointerList();
      }
          
      private void UpdateUiPointerList()
      {
          for (int i = 0; i < _targetTransformList.Count; i++)
          {
              Destroy(_targetTransformList[i].gameObject);
          }
          
          _targetTransformList.Clear();
          
          for (int i = 0; i < _targetTransformList.Count; i++)
          {
              GameObject _uiPointerGameObject = Instantiate(_uiPointerPrefabGameObect);
              _uiPointerGameObject.transform.SetParent(_parentCanvas.transform);
  
              UiPointer uiPointer = _uiPointerGameObject.GetComponent<UiPointer>();
  
              if (uiPointer != null) _uiPointerList.Add(uiPointer);
              uiPointer.SetTargetTransform(_targetTransformList[i]);
              uiPointer.SetReferenceTransform(_referenceTransform);
          }
      }
  
  
      #region Set Functions
      public void SetTargetTransforms(List<Transform> targetTransformList)
      {
          _targetTransformList = targetTransformList;
      }
  
      public void AddTargetTransform(Transform newTransform)
      {
          _targetTransformList.Add(newTransform);
      }
  
      public void RemoveTargetTransform(Transform targetTransform)
      {
          _targetTransformList.Remove(targetTransform);
      }
  
      public void SetReferenceTransform(Transform targetTransform)
      {
          _referenceTransform = targetTransform;
      }
      #endregion
      
      
  }  
}

