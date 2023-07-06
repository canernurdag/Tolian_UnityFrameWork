using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tolian.ScriptableSystem
{
    public abstract class EventListener<T> : MonoBehaviour
    {
        [SerializeField] protected List<EventChannel<T>> _eventChannels = new List<EventChannel<T>>();
        public List<EventChannel<T>>EventChannels => _eventChannels;
        
        protected Dictionary<EventChannel<T>, Action<T>> _eventChannelActionDictionary =
            new Dictionary<EventChannel<T>, Action<T>>();

        protected void Awake()
        {
            CreateDictionary();
        }

        protected void OnEnable()
        {
            for (int i = 0; i < _eventChannels.Count; i++)
            {
                _eventChannels[i].SubscribeEventListener(this);
            }
        }

        protected void OnDisable()
        {
            for (int i = 0; i < _eventChannels.Count; i++)
            {
                _eventChannels[i].UnsubscribeEventListener(this);
            }
        }

        public void OnInvokeRelatedActions(T eventParameter, EventChannel<T> eventChannel)
        {
            var action = _eventChannelActionDictionary[eventChannel];
            action?.Invoke(eventParameter);
          
        }

        public void SetActionDelegates(EventChannel<T> eventChannel, Action<T> newFunction)
        {
            var targetAction = _eventChannelActionDictionary[eventChannel];
            targetAction += newFunction;
            _eventChannelActionDictionary[eventChannel] = targetAction;
        }

        protected void CreateDictionary()
        {
            for (int i = 0; i < _eventChannels.Count; i++)
            {
                Action<T> newAction = null;
                    
                _eventChannelActionDictionary.Add(_eventChannels[i], newAction);
            }
        }


      
    }



}
