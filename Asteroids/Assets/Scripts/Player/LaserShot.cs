using System.Collections;
using UnityEngine;

namespace Player
{
    public class LaserShot : IPlayerChargeableAttack
    {
        private int currentShotsCount=0;

        private GameObject _laserPrefab;
        
        private float _laserShotDuration;
        
        private int _maxShotsCount;
        private float _rechargeTime;

        private float _reloadTime;
        private bool _isReloading;
        private float _chargePercent;

        public LaserShot(Transform playerTransform,GameObject laserPrefab,float laserShotDuration ,int maxShotsCount, float rechargeTime)
        {
            _laserPrefab = laserPrefab;
            _laserShotDuration = laserShotDuration;
            _maxShotsCount = maxShotsCount;
            _rechargeTime = rechargeTime;
        }
        public IEnumerator Fire()
        {
            if (!HaveAmmo())
                yield break;

            currentShotsCount--;
            
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