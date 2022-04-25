using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Object = System.Object;

namespace Player
{
    public class PlayerAttack
    {
        private Transform _playerTransform;

        public PlayerAttack(Transform transform, GameObject bulletPrefab)
        {
            _playerTransform = transform;
        }

        public void ShootSomething(GameObject ammoPrefab, float ammoSpeed)
        {
            var ammoInstance = UnityEngine.Object.Instantiate(ammoPrefab, _playerTransform.position,_playerTransform.rotation);
            ammoInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*ammoSpeed,ForceMode2D.Impulse);
        }

    }
}