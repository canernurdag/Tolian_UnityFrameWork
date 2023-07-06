using UnityEngine;

namespace Tolian.Runtime.Core.Actors.Controllers.HealthSystem
{
    public abstract class ControllerActorHealth : MonoBehaviour
    {
        public int Health { get; protected set; }
        
        public virtual void SetHealth(int targetHealth)
        {
            Health = targetHealth;
        }
    
        public void GetDamage(int damageAmount)
        {
            int newHealth = Health - damageAmount;
            if (newHealth < 0) newHealth = 0;
        
            SetHealth(newHealth);
            
            DamageZeroCallback();
        }

        public abstract void DamageZeroCallback();
    }
}

