using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tolian.Runtime.Core.Actors.StackSystem
{
    /// <summary>
    /// This class creates and handles stack of any types of objects.
    /// </summary>
    public class ControllerStack : MonoBehaviour
    {
        #region References
        [SerializeField] private StackSlot _stackSlotPrefab;
        [SerializeField] private Transform _stackSlotStartPosTransform;
        #endregion

        #region Internals
        public List<StackSlot> StackSlots { get; private set; }= new List<StackSlot>();
    
        [SerializeField] protected float _distanceBetweenY;
        [SerializeField] protected float _distanceBetweenX;
        [SerializeField] protected float _distanceBetweenZ;
    
        [SerializeField] protected float _maxYSize = 10;
        [SerializeField] protected float _maxXSize = 1;
        [SerializeField] protected float _maxZSize = 1;
        #endregion

        private void Awake()
        {
            CreateStack();
        }

        private void CreateStack()
        {
            for (int i = 0; i < _maxXSize; i++)
            {
                for (int j = 0; j < _maxZSize; j++)
                {
                    for (int k = 0; k < _maxYSize; k++)
                    {
                        GameObject stackSlotGO = Instantiate(_stackSlotPrefab.gameObject);
                        stackSlotGO.transform.SetParent(transform);
                        StackSlot stackSlot = stackSlotGO.GetComponent<StackSlot>();
                    
                        StackSlots.Add(stackSlot);
                        stackSlot.transform.transform.position = _stackSlotStartPosTransform.position + new Vector3(i*_distanceBetweenX, k*_distanceBetweenY, j*_distanceBetweenZ);
                    }
                }
            }
        }

        private StackSlot GetNextEmptyStackSlot()
        {
            if (StackSlots.Any(x => x.InsideObjectTransform == null))
            {
                return StackSlots.First(x => x.InsideObjectTransform == null);
            }

            return null;
        }
        
        private StackSlot GetTopFullStackSlot()
        {
            if (StackSlots.Any(x => x.InsideObjectTransform != null))
            {
                return StackSlots.Last(x => x.InsideObjectTransform != null);
            }

            return null;
        }

    } 
}

