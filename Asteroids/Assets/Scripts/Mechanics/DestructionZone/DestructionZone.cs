using System;
using UnityEngine;

namespace Mechanics.DestructionZone
{
    public class DestructionZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Enemy") || col.CompareTag("Ammo"))
                Destroy(col.gameObject);
        }
    }
}
