using UnityEngine;

namespace Enemies
{
    public interface IEnemyMovement
    {
        Transform SelfTransform { get; set; }
        Transform PlayerTransform { get; set; }
        float MoveSpeed { get; set; }
        void Move();
    }
}