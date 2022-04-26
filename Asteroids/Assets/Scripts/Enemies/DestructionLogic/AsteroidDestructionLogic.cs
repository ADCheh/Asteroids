using Enemies.Infrastructure;
using Game;
using UnityEngine;
using Random = System.Random;

namespace Enemies.DestructionLogic
{
    public class AsteroidDestructionLogic : IDestructionLogic
    {
        private readonly Transform _parentTransform;
        private readonly GameObject _asteroidPiecePrefab;
        private readonly int _destructionScore;
        
        private Random rnd = new Random();

        public AsteroidDestructionLogic(Transform parentTransform, GameObject asteroidPiecePrefab,int destructionScore)
        {
            _parentTransform = parentTransform;
            _asteroidPiecePrefab = asteroidPiecePrefab;
            _destructionScore = destructionScore;
        }

        public void HandleDestruction()
        {
            int piecesCount = rnd.Next(2, 5);
            
            for (int i = 0; i < piecesCount; i++)
            {
                var pieceInstance = UnityEngine.Object.Instantiate(_asteroidPiecePrefab, _parentTransform.position, Quaternion.identity);
                pieceInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(rnd.Next(-10,10),rnd.Next(-10,10)).normalized* rnd.Next(1,4),ForceMode2D.Impulse);
            }
            AddScore(_destructionScore);
            Object.Destroy(_parentTransform.gameObject);
        }

        public void AddScore(float score)
        {
            GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>().scoreCounter.AddScore(score);
        }
    }
}