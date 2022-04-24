using UnityEngine;

namespace Enemies
{
    public class AsteroidMovement
    {
        private Transform _transform;
        private Transform _playerTransform;
        private readonly float _asteroidSpeed;
        public AsteroidMovement(Transform playerTransform, Transform transform, float movementSpeed)
        {
            _playerTransform = playerTransform;
            _transform = transform;
            _asteroidSpeed = movementSpeed;
        }

        public void Move()
        {
            _transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.position.x,_playerTransform.position.y) * _asteroidSpeed,ForceMode2D.Impulse);
        }
    }
}