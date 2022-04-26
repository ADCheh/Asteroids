using System.Collections;

namespace Player
{
    public interface IPlayerChargeableAttack
    {
        IEnumerator Fire();
        bool NeedToReload();
        int CurrentAmmoCount();
        IEnumerator Reload();
        float ReloadStatus();
    }
}