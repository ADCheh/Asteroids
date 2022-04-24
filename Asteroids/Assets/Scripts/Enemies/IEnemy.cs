using UnityEngine;

namespace Enemies
{
    public interface IEnemy
    {
        Transform Player { get; set; }
        IEnemyMovement MovementLogic { get; }
    }
}