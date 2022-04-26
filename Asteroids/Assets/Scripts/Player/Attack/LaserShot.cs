using System.Collections;
using UnityEngine;

namespace Player.Attack
{
    public class LaserShot : IPlayerChargeableAttack
    {
        private int currentShotsCount=0;

        private readonly GameObject _laserPrefab;
        
        private readonly float _laserShotDuration;
        
        private readonly int _maxShotsCount;
        private readonly float _rechargeTime;

        private float _reloadTime;
        private bool _isReloading;
        private float _chargePercent;
        private readonly Transform _playerTransform;

        public LaserShot(Transform playerTransform,GameObject laserPrefab,float laserShotDuration ,int maxShotsCount, float rechargeTime)
        {
            _laserPrefab = laserPrefab;
            _laserShotDuration = laserShotDuration;
            _maxShotsCount = maxShotsCount;
            _rechargeTime = rechargeTime;
            _playerTransform = playerTransform;
        }
        public IEnumerator Fire()
        {
            AdjustPosition();

            if (!HaveAmmo())
                yield break;

            currentShotsCount--;

            AdjustPosition();

            _laserPrefab.SetActive(true);

            yield return new WaitForSeconds(_laserShotDuration);
            _laserPrefab.SetActive(false);
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

        private void AdjustPosition()
        {
            _laserPrefab.transform.position = _playerTransform.position;
            _laserPrefab.transform.rotation = _playerTransform.rotation;
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