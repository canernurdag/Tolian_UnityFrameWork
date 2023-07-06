using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tolian.Runtime.Systems.ServiceLocatorDomain
{
    public class ServiceLocatorSystem : MonoBehaviour
    {
        private List<MonoBehaviourService> _monoBehaviourServices = new();

        public void Register(MonoBehaviourService targetMonoBehaviourService)
        {
            bool isServiceExist = _monoBehaviourServices.Any(x => x == targetMonoBehaviourService);

            if (!isServiceExist)
            {
                _monoBehaviourServices.Add(targetMonoBehaviourService);
            }
        }
        public void Unregister(MonoBehaviourService targetMonoBehaviourService)
        {
            bool isServiceExist = _monoBehaviourServices.Any(x => x == targetMonoBehaviourService);

            if (isServiceExist)
            {
                _monoBehaviourServices.Remove(targetMonoBehaviourService);
            }
        }
        
        public T GetService<T>() where T: MonoBehaviourService, new()
        {
            Type type = typeof(T);
            
            bool isServiceExist = _monoBehaviourServices.Any(x => x.GetType() == typeof(T));

            if (isServiceExist)
            {
                return (T)_monoBehaviourServices.First(x => x.GetType() == typeof(T));;
            }
            
            throw new ArgumentOutOfRangeException();
        }
    }
}


