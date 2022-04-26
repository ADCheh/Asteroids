using UnityEngine;

namespace Player.Attack
{
    public class BulletShot : IPlayerAttack
    {

        private Transform _playerTransform;
        private GameObject _ammoPrefab;
        private float _ammoSpeed;
        
        public BulletShot(Transform playerTransform,GameObject ammoPrefab, float ammoSpeed)
        {
            _playerTransform = playerTransform;
            _ammoPrefab = ammoPrefab;
            _ammoSpeed = ammoSpeed;
        }


        public void Fire()
        {
            var ammoInstance = UnityEngine.Object.Instantiate(_ammoPrefab, _playerTransform.position,_playerTransform.rotation);
            ammoInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*_ammoSpeed,ForceMode2D.Impulse);
        }
    }
}