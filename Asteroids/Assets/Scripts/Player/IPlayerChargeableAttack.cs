using System.Collections;

namespace Player
{
    public interface IPlayerChargeableAttack : IPlayerAttack
    {
        bool NeedToReload();
        int CurrentAmmoCount();
        IEnumerator Reload();
    }
}