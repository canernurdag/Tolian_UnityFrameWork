using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class UiStar : MonoBehaviour
    {
        public List<ParticleSystem> ParticleSystems;

        private void Awake()
        {
            ParticleSystems = GetComponentsInChildren<ParticleSystem>(true).ToList();
        }
    }

}
