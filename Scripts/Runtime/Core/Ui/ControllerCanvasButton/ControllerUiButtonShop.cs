using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.GameSystem;
using Tolian.Runtime.Systems.UiDomain;
using UnityEngine;

namespace Tolian.Runtime.Core.UiSystem
{
    public class ControllerUiButtonShop : ControllerCanvasButtons
    {
        private CanvasUi _canvasUi;
        private ControllerOpenCloseShopCanvas _controllerOpenCloseShopCanvas;

        private void Awake()
        {
            _canvasUi = GetComponent<CanvasUi>();
            _controllerOpenCloseShopCanvas = GetComponent<ControllerOpenCloseShopCanvas>();
        }

        public void ExitButtonFunction()
        {
            if (_controllerOpenCloseShopCanvas)
            {
                _controllerOpenCloseShopCanvas.CloseUiCanvas(_canvasUi.CanvasUiParts);
                ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerUi>().ControllerUiCanvases.SetCanvasesAccordingToGameState(GameStateType.LevelOpened);
            
                var managerGame = ManagerServiceLocator.Instance.ServiceLocatorSystem.GetService<ManagerGame>();
                managerGame.SetCurrentGameStateType(GameStateType.LevelOpened);
            }
        }
    }
}

