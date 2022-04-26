using UnityEngine.UI;

namespace Game.Score
{
    public class ScoreCounter
    {
        private Text _scoreText;

        private float _currentScore;
        
        public ScoreCounter(Text scoreText)
        {
            _scoreText = scoreText;
        }

        public void AddScore(float score)
        {
            _currentScore += score;
            _scoreText.text = _currentScore.ToString();
        }
    }
}