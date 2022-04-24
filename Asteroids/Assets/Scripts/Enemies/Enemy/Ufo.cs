﻿using Enemies.Infrastructure;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Enemy
{
    public class Ufo : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;
        public Transform Player { get; set; }
        public IEnemyMovement MovementLogic { get; set; }

        private void Start()
        {
            MovementLogic = new UfoMovement(Player,transform, MoveSpeed);
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