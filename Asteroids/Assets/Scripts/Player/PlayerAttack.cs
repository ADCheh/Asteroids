using UnityEngine;

namespace Player
{
    public class PlayerAttack
    {
        private Transform _playerTransform;

        private float _lastDelayedShot;

        public PlayerAttack(Transform transform, GameObject bulletPrefab)
        {
            _playerTransform = transform;
        }

        public void ShootSomething(GameObject ammoPrefab, float ammoSpeed)
        {
            var ammoInstance = UnityEngine.Object.Instantiate(ammoPrefab, _playerTransform.position,_playerTransform.rotation);
            ammoInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*ammoSpeed,ForceMode2D.Impulse);
        }
        
        public void ShootSomethingWithDelay(GameObject ammoPrefab, float ammoSpeed, float delay)
        {
            if (!CheckDelay(delay))
                return;
            
            _lastDelayedShot = Time.time;
            var ammoInstance = UnityEngine.Object.Instantiate(ammoPrefab, _playerTransform.position,_playerTransform.rotation);
            ammoInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*ammoSpeed,ForceMode2D.Impulse);
        }

        private bool CheckDelay(float delay)
        {
            if (Time.time > _lastDelayedShot + delay)
                return true;

            return false;
        }
    }
}