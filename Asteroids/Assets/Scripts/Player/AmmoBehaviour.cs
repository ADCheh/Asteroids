using UnityEngine;

namespace Player
{
    public class AmmoBehaviour : MonoBehaviour
    {
        public bool DestroyAmmoOnHit;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                if(DestroyAmmoOnHit)
                    Destroy(gameObject);
            }
        }
    }
}