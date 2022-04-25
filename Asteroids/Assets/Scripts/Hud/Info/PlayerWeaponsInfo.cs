using Player;
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

        public string GetCurrentWeaponChargesString()
        {
            return $"Current laser charges: {_laserAttack.CurrentAmmoCount()}";
        }
    }
}