using UnityEngine;

namespace Enemies
{
    public class UFOMovement
    {
        private readonly Transform _playerTransform;
        private readonly float _movementSpeed;
        private Transform _transform;

        public UFOMovement(Transform playerTransform,Transform transform,float movementSpeed)
        {
            _playerTransform = playerTransform;
            _transform = transform;
            _movementSpeed = movementSpeed;
        }
        
        public void Move()
        {
            _transform.position = Vector3.Lerp(_transform.position, _playerTransform.position, Time.deltaTime * _movementSpeed);
        }
    }
}