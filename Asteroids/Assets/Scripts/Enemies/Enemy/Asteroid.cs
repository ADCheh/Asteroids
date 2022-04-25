using System;
using Enemies.Infrastructure;
using Enemies.Logic;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Enemy
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;

        public GameObject asteroidPiecePrefab;
        public Transform Player { get; set;  }
        public IEnemyMovement MovementLogic { get; set; }
        public IDestructionLogic DestructionLogic { get; set; }

        private void Start()
        {
            DestructionLogic = new AsteroidDestructionLogic(transform, asteroidPiecePrefab);
            MovementLogic = new AsteroidMovement(Player, transform,MoveSpeed);
            MovementLogic.Move();
        }
    }
}