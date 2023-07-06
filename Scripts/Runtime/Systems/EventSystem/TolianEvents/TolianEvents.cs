using Tolian.Runtime.Core.Managers.GameSystem;
using UnityEngine;

namespace Tolian.Runtime.Systems.EventDomain
{
    public class TolianEvents
    {
    
    }
    
    //BASE CLASSESS
    
    public class EventBool : TolianEvent<bool>
    {
        
    }
    
    public class EventFloat : TolianEvent<float>
    {
        
    }
    
    public class EventGameObject : TolianEvent<GameObject>
    {
        
    }
    
    public class EventGameState : TolianEvent<GameStateType>
    {
        
    }
    
    public class EventInt : TolianEvent<int>
    {
        
    }
    
    public class EventVector3 : TolianEvent<Vector3>
    {
        
    }
    
    //IN ACTION CLASSES
    public class OnGameStateChange : EventGameState
    {
        
    }
   
    
}

