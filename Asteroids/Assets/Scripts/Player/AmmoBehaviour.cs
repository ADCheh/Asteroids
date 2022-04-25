using System;
using Enemies.Infrastructure;
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
                HandleHit(col);
                if(DestroyAmmoOnHit)
                    Destroy(gameObject);
            }
        }

        private void HandleHit(Collider2D col)
        {
            col.GetComponent<IEnemy>()?.DestructionLogic?.HandleDestruction();
            Destroy(col.gameObject);
        }
    }
}