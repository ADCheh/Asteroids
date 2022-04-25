using System;
using Enemies.Infrastructure;
using UnityEngine;
using Random = System.Random;

namespace Enemies.Movement
{
    public class AsteroidMovement : IEnemyMovement
    {
        public Transform SelfTransform { get; set; }
        public Transform PlayerTransform { get; set; }
        public float MoveSpeed { get; set; }

        private Vector3 _playerPosition;
        
        //
        private System.Random rnd = new Random();
        //
        
        public AsteroidMovement(Transform playerTransform, Transform transform, float movementSpeed)
        {
            SelfTransform = transform;
            PlayerTransform = playerTransform;
            MoveSpeed = movementSpeed;
        }

        public void Move()
        {
            float forceX = PlayerTransform.position.x - SelfTransform.position.x + GetRandomBoarders(5);//
            float forceY = PlayerTransform.position.y - SelfTransform.position.y + GetRandomBoarders(5);//
            
            SelfTransform.GetComponent<Rigidbody2D>().
                AddForce(new Vector2(forceX,forceY).normalized * MoveSpeed,ForceMode2D.Impulse);
        }

        private int GetRandomBoarders(int range)
        {
            return rnd.Next(-range, range);
        }
    }
}