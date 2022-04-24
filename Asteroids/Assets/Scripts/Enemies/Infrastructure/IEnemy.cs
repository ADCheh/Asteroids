using UnityEngine;

namespace Enemies.Infrastructure
{
    public interface IEnemy
    {
        Transform Player { get; set; }
        IEnemyMovement MovementLogic { get; set; }
    }
}