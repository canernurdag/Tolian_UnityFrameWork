
using Tolian.Runtime.Core.Managers;

namespace Tolian.Runtime.Core.Actors.Controllers.ControlSystem
{
    public abstract class ControllerControllerBasePlayer : ControllerControllerBase
    {
        #region References
        public ManagerInput ManagerInput { get; protected set; }
        #endregion
    
        protected virtual void Start()
        {
            ManagerInput = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerInput>();
        }
    }
   
}
