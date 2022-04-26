using Game.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ScoreController : MonoBehaviour
    {
        public Text _scoreText;

        public ScoreCounter scoreCounter;

        private void Start()
        {
            scoreCounter = new ScoreCounter(_scoreText);
        }
    }
}