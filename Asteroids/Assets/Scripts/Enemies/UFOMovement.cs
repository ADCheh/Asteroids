using UnityEngine;

namespace Enemies
{
    public class UFOMovement : IEnemyMovement
    {
        public Transform SelfTransform { get; set; }
        public Transform PlayerTransform { get; set; }
        public float MoveSpeed { get; set; }
        
        public UFOMovement(Transform playerTransform,Transform transform,float movementSpeed)
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