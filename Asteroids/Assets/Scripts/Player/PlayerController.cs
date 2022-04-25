using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float drag;
        public float rotationSpeed;
        
        public GameObject bulletPrefab;
        public GameObject laserPrefab;
        public float bulletSpeed;
        public float laserSpeed;
        public int laserShotsMaxCount;
        public float laserShotsChargeTime;

        private float _currentChargesCount;

        private Rigidbody2D _rigidbody;
        private PlayerMovement _movement;
        private PlayerAttack _attack;

        private IPlayerAttack _bullet;
        public IPlayerChargeableAttack _laser;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(transform,_rigidbody);
            _attack = new PlayerAttack(transform, laserShotsMaxCount,laserShotsChargeTime);

            _bullet = new BulletShot(transform, bulletPrefab, bulletSpeed);
            _laser = new LaserShot(transform, laserPrefab, laserSpeed, laserShotsMaxCount, laserShotsChargeTime);
            
            StartCoroutine(_laser.Reload());
        }
        void Update()
        {
            _movement.MoveForward(speed,drag);
            _movement.Rotate(rotationSpeed);

            if (Input.GetMouseButtonDown(0))
            {
                _bullet.Fire();
            }
            
            if (_laser.NeedToReload())
                StartCoroutine(_laser.Reload());
            
            if (Input.GetMouseButtonDown(1))
            {
                _laser.Fire();
            }
        }
    }
}
