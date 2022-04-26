using System;
using Enemies.Infrastructure;
using Enemies.Logic;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Enemy
{
    public class Ufo : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;
        public Transform Player { get; set; }
        public IEnemyMovement MovementLogic { get; set; }
        public IDestructionLogic DestructionLogic { get; set; }

        public int ScoreForDestruction;

        private void Start()
        {
            DestructionLogic = new UfoDestructionLogic(transform, ScoreForDestruction);
            MovementLogic = new UfoMovement(Player,transform, MoveSpeed);
        }

        private void Update()
        {
            MovementLogic.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ammo"))
            {
                DestructionLogic.HandleDestruction();
            }
        }
    }
}