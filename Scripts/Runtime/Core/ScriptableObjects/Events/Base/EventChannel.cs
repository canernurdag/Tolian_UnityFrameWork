using System.Collections;
using System.Collections.Generic;
using Tolian.ScriptableSystem;
using UnityEngine;

namespace Tolian.ScriptableSystem
{
    public abstract class EventChannel<T> : ScriptableObject
    {
        protected List<EventListener<T>> _eventListeners = new List<EventListener<T>>();
        
        public virtual void RaiseEvent(T eventParameter)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnInvokeRelatedActions(eventParameter, this);;
            }
        }

        public virtual void SubscribeEventListener(EventListener<T> eventListener)
        {
            if (!_eventListeners.Contains(eventListener))
            {
                _eventListeners.Add(eventListener);
            }
        }

        public virtual void UnsubscribeEventListener(EventListener<T> eventListener)
        {
            if(_eventListeners.Contains(eventListener))
            {
                _eventListeners.Remove(eventListener);
            }
        }
    }
}
