using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class EndgameLogic
    {
        private readonly GameObject _endGameHud;

        public EndgameLogic(PlayerController playerController ,GameObject endGameHud)
        {
            _endGameHud = endGameHud;
            playerController.PlayerIsDead.AddListener(HandleEnd);
        }

        public void HandleEnd()
        {
            Time.timeScale = 0;
            _endGameHud.gameObject.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene("Main");
        }

        public void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
