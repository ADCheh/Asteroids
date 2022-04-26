using System.Collections;
using UnityEngine;

namespace Player
{
    public class LaserShot : IPlayerChargeableAttack
    {
        private int currentShotsCount=0;
        
        private Transform _playerTransform;
        private GameObject _laserPrefab;
        private float _laserSpeed;
        private int _maxShotsCount;
        private float _rechargeTime;

        private float _reloadTime;
        private bool _isReloading;
        private float _chargePercent;
        
        public LaserShot(Transform playerTransform,GameObject laserPrefab,float laserSpeed ,int maxShotsCount, float rechargeTime)
        {
            _playerTransform = playerTransform;
            _laserPrefab = laserPrefab;
            _laserSpeed = laserSpeed;
            _maxShotsCount = maxShotsCount;
            _rechargeTime = rechargeTime;
        }
        public void Fire()
        {
            if (!HaveAmmo())
                return;

            currentShotsCount--;
            
            var ammoInstance = UnityEngine.Object.Instantiate(_laserPrefab, _playerTransform.position,_playerTransform.rotation);
            ammoInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerTransform.up.x,_playerTransform.up.y)*_laserSpeed,ForceMode2D.Impulse);
        }

        public IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(_rechargeTime);
            currentShotsCount++;
            _isReloading = false;
            _reloadTime = 0;
        }

        public int CurrentAmmoCount()
        {
            return currentShotsCount;
        }

        public bool NeedToReload()
        {
            return NotFullAmmo() && !IsReloading();
        }

        public float ReloadStatus()
        {
            if(_isReloading)
                _reloadTime += Time.deltaTime;
            
            _chargePercent = _reloadTime / _rechargeTime;
            return  _chargePercent;
        }

        private bool NotFullAmmo()
        {
            return currentShotsCount < _maxShotsCount;
        }

        private bool IsReloading()
        {
            return _isReloading;
        }

        private bool HaveAmmo()
        {
            return currentShotsCount > 0;
        }
    }
}