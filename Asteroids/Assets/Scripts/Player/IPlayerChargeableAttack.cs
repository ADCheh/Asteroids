using System.Collections;

namespace Player
{
    public interface IPlayerChargeableAttack : IPlayerAttack
    {
        bool NotFullAmmo();

        bool IsReloading();

        int CurrentAmmoCount();
        IEnumerator Reload();
    }
}