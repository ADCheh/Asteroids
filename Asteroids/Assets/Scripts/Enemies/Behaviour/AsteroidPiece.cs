using UnityEngine;

namespace Enemies.Behaviour
{
    public class AsteroidPiece : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ammo") || col.CompareTag("Laser"))
            {
                Destroy(gameObject);
            }
        }
    }
}
