using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tolian.Runtime.Core.Actors.Controllers.AnimatorSystem;
using UnityEngine;

namespace Tolian.Runtime.Core.Actors.Characters.Controller.RagdollSystem
{
    public class ControllerCharacterRagdoll : MonoBehaviour
    {
        [SerializeField] private Transform _parentTransform;

        private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
        private List<Collider> _colliders = new List<Collider>();
        private Collider _mainCollider;

        private ControllerActorAnimator _controllerActorAnimator;

        private void Awake()
        {
            _rigidbodies = _parentTransform.GetComponentsInChildren<Rigidbody>().ToList();
            _colliders = _parentTransform.GetComponentsInChildren<Collider>().ToList();
            _mainCollider = GetComponent<Collider>();
            _controllerActorAnimator = GetComponent<ControllerActorAnimator>();
        }

        private void Start()
        {
            SetRagdollActiveness(false);
        }
    

        public void SetRagdollActiveness(bool value)
        {
            _controllerActorAnimator.SetAnimatorActiveness(!value);

            for (int i = 0; i < _rigidbodies.Count; i++)
            {
                _rigidbodies[i].isKinematic = !value;
            
            }

            for (int i = 0; i < _colliders.Count; i++)
            {
                _colliders[i].enabled = value;
            }
         
            _mainCollider.enabled = !value;

     
        }
    }
}

