using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float drag;
        public float rotationSpeed;

        private Rigidbody2D _rigidbody;
        private PlayerMovement _movement;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(transform,_rigidbody);
        }
        void Update()
        {
            _movement.MoveForward(speed,drag);
            _movement.Rotate(rotationSpeed);
        }
    }
}
