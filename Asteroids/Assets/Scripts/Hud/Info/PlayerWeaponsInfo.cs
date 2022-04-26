using Player;
using Player.Attack;
using UnityEngine;

namespace Hud.Info
{
    public class PlayerWeaponsInfo
    {
        public IPlayerChargeableAttack _laserAttack;
        public PlayerWeaponsInfo(GameObject Player)
        {
            _laserAttack = Player.GetComponent<PlayerController>()._laser;
        }

        public float GetReloadStatus()
        {
            return _laserAttack.ReloadStatus();
        }

        public string GetCurrentWeaponChargesString()
        {
            return $"Current laser charges: {_laserAttack.CurrentAmmoCount()}";
        }
    }
}