namespace Tolian.Runtime.Systems.ServiceLocatorDomain
{
    public interface IService
    {
        void RegisterToManagerServiceLocator();

        void UnregisterFromManagerServiceLocator();
    }
}


