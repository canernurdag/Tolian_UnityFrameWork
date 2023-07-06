using Tolian.Runtime.Core.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(100)]
public class GameStarter : MonoBehaviour
{
    private void Start()
    {
        ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerLevel>().OpenTheSameLevel(true);
    }
}
