using System;
using UnityEngine;
using UnityEngine.Events;

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
        public float laserShotDuration;
        public int laserShotsMaxCount;
        public float laserShotsChargeTime;

        private float _currentChargesCount;

        private Rigidbody2D _rigidbody;
        private PlayerMovement _movement;

        private IPlayerAttack _bullet;
        public IPlayerChargeableAttack _laser;

        public UnityEvent PlayerIsDead = new UnityEvent();

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(transform,_rigidbody);

            _bullet = new BulletShot(transform, bulletPrefab, bulletSpeed);
            _laser = new LaserShot(transform, laserPrefab, laserShotDuration, laserShotsMaxCount, laserShotsChargeTime);

            StartCoroutine(_laser.Reload());
        }
        private void Update()
        {
            if(Time.timeScale == 0)
                return;
            
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
                StartCoroutine(_laser.Fire());
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                PlayerIsDead?.Invoke();
            }
        }
    }
}
