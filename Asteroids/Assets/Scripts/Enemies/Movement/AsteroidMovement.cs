using Enemies.Infrastructure;
using UnityEngine;

namespace Enemies.Movement
{
    public class AsteroidMovement : IEnemyMovement
    {
        public Transform SelfTransform { get; set; }
        public Transform PlayerTransform { get; set; }
        public float MoveSpeed { get; set; }

        private Vector3 _playerPosition;
        
        public AsteroidMovement(Transform playerTransform, Transform transform, float movementSpeed)
        {
            SelfTransform = transform;
            PlayerTransform = playerTransform;
            MoveSpeed = movementSpeed;
            //_playerPosition = PlayerTransform.position;
        }

        public void Move()
        {
            float forceX = PlayerTransform.position.x - SelfTransform.position.x;
            float forceY = PlayerTransform.position.y - SelfTransform.position.y;
            
            SelfTransform.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX,forceY).normalized * MoveSpeed,ForceMode2D.Impulse);
        }
    }
}