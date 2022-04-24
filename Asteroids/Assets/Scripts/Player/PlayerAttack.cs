using Unity.Mathematics;
using UnityEngine;
using Object = System.Object;

namespace Player
{
    public class PlayerAttack
    {
        private Transform _playerTransform;
        private GameObject _bulletPrefab;
        private float bulletSpeed = 10f;

        public PlayerAttack(Transform transform, GameObject bulletPrefab)
        {
            _playerTransform = transform;
            _bulletPrefab = bulletPrefab;
        }

        public void ShootBullet()
        {
            var bulletInstance = UnityEngine.Object.Instantiate(_bulletPrefab, _playerTransform.position,Quaternion.identity);
            //bulletInstance.GetComponent<Rigidbody2D>().velocity = _playerTransform.up * Time.deltaTime * bulletSpeed;
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*bulletSpeed,ForceMode2D.Impulse);
        }
    }
}