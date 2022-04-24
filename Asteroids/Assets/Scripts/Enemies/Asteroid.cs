using System;
using UnityEngine;

namespace Enemies
{
    public class Asteroid : MonoBehaviour
    {
        public Transform Player;
        
        public float SpawnDelay;
        
        private AsteroidMovement _asteroidMovement;
        private void Start()
        {
            _asteroidMovement = new AsteroidMovement(Player, transform,0.5f);
            _asteroidMovement.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}