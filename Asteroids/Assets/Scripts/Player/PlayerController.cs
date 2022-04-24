using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float drag;
        public float rotationSpeed;
        public GameObject bulletPrefab;

        private Rigidbody2D _rigidbody;
        private PlayerMovement _movement;
        private PlayerAttack _attack;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(transform,_rigidbody);
            _attack = new PlayerAttack(transform,bulletPrefab);
        }
        void Update()
        {
            _movement.MoveForward(speed,drag);
            _movement.Rotate(rotationSpeed);

            if (Input.GetMouseButtonDown(0))
            {
                _attack.ShootBullet();
            }
        }
    }
}
