using System;
using UnityEngine;

namespace Enemies
{
    public class UFO : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;
        public float SpawnDelay;
        public Transform Player { get; set; }
        public IEnemyMovement MovementLogic { get; private set; }

        private void Start()
        {
            MovementLogic = new UFOMovement(Player,transform, MoveSpeed);
        }

        private void Update()
        {
            MovementLogic.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}