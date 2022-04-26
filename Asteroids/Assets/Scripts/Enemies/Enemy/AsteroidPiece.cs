using UnityEngine;

namespace Enemies.Enemy
{
    public class AsteroidPiece : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ammo"))
            {
                Destroy(gameObject);
            }
        }
    }
}
