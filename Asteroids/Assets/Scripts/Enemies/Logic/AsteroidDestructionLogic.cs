using UnityEngine;
using Random = System.Random;

namespace Enemies.Logic
{
    public class AsteroidDestructionLogic : IDestructionLogic
    {
        private Transform _parentTransform;
        private GameObject _asteroidPiecePrefab;
        
        private Random rnd = new Random();

        public AsteroidDestructionLogic(Transform parentTransform, GameObject asteroidPiecePrefab)
        {
            _parentTransform = parentTransform;
            _asteroidPiecePrefab = asteroidPiecePrefab;
        }

        public void HandleDestruction()
        {
            int piecesCount = rnd.Next(2, 5);
            
            for (int i = 0; i < piecesCount; i++)
            {
                var pieceInstance = UnityEngine.Object.Instantiate(_asteroidPiecePrefab, _parentTransform.position, Quaternion.identity);
                pieceInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(rnd.Next(-10,10),rnd.Next(-10,10)).normalized* rnd.Next(1,4),ForceMode2D.Impulse);
            }
            
            GameObject.Destroy(_parentTransform.gameObject);
        }
    }
}