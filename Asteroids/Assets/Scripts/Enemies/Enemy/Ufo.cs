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

        private void Start()
        {
            MovementLogic = new UfoMovement(Player,transform, MoveSpeed);
        }

        private void Update()
        {
            MovementLogic.Move();
        }
    }
}