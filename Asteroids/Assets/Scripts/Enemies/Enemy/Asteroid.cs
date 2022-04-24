using Enemies.Infrastructure;
using Enemies.Logic;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Enemy
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;

        public GameObject asteroidPiecePrefab;
        public Transform Player { get; set;  }
        public IEnemyMovement MovementLogic { get; set; }

        private AsteroidDestructionLogic _destructionLogic;

        private void Start()
        {
            _destructionLogic = new AsteroidDestructionLogic(transform, asteroidPiecePrefab);
            MovementLogic = new AsteroidMovement(Player, transform,MoveSpeed);
            MovementLogic.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Bullet"))
            {
                _destructionLogic.InstantiatePieces();
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}