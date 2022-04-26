using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameEndController : MonoBehaviour
    {
        public PlayerController PlayerController;
        public GameObject EndgameHud;
        public Text EndgameText;
        
        private EndgameLogic _gameEndingController;
        private void Start()
        {
            _gameEndingController = new EndgameLogic(PlayerController,EndgameHud, EndgameText);
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
