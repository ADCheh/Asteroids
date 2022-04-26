using Player;
using UnityEngine;

namespace Game
{
    public class GameEndController : MonoBehaviour
    {
        public PlayerController PlayerController;
        public GameObject EndgameHud;
        
        private EndgameLogic _gameEndingController;
        private void Start()
        {
            _gameEndingController = new EndgameLogic(PlayerController,EndgameHud);
        }

        public void RestartButtonHandler()
        {
            _gameEndingController.Restart();
        }

        public void QuitButtonHandler()
        {
            _gameEndingController.Quit();
        }

    }
}
