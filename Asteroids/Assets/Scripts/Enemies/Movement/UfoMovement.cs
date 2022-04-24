using Enemies.Infrastructure;
using UnityEngine;

namespace Enemies.Movement
{
    public class UfoMovement : IEnemyMovement
    {
        public Transform SelfTransform { get; set; }
        public Transform PlayerTransform { get; set; }
        public float MoveSpeed { get; set; }
        
        public UfoMovement(Transform playerTransform,Transform transform,float movementSpeed)
        {
            SelfTransform = transform;
            PlayerTransform = playerTransform;
            MoveSpeed = movementSpeed;
        }

        public void Move()
        {
            SelfTransform.position = Vector3.Lerp(SelfTransform.position, PlayerTransform.position, Time.deltaTime * MoveSpeed);
        }
    }
}