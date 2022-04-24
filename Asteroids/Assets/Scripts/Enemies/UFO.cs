using System;
using UnityEngine;

namespace Enemies
{
    public class UFO : MonoBehaviour
    {
        public float SpawnDelay;
        
        public Transform Player;
        
        private UFOMovement _ufoMovement;

        private void Start()
        {
            _ufoMovement = new UFOMovement(Player,transform, 0.1f);
        }

        private void Update()
        {
            _ufoMovement.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}