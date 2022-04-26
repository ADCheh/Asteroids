using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class EndgameLogic
    {
        private readonly GameObject _endGameHud;
        private readonly Text _endGameTextField;

        public EndgameLogic(PlayerController playerController ,GameObject endGameHud, Text endGameTextField)
        {
            _endGameHud = endGameHud;
            _endGameTextField = endGameTextField;
            playerController.PlayerIsDead.AddListener(HandleEnd);
        }

        public void HandleEnd()
        {
            Time.timeScale = 0;
            _endGameTextField.text = $"GG\n\n\n Your score: {GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>().scoreCounter.GetScore()}\n\n" +
                                     $"To restart the game click button below";
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
