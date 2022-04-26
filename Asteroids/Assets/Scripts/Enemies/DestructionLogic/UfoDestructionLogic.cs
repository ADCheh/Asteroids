using Enemies.Infrastructure;
using Game;
using UnityEngine;

namespace Enemies.DestructionLogic
{
    public class UfoDestructionLogic : IDestructionLogic
    {
        private readonly Transform _parentTransform;
        private readonly int _destructionScore;

        public UfoDestructionLogic(Transform parentTransform, int destructionScore)
        {
            _parentTransform = parentTransform;
            _destructionScore = destructionScore;
        }
        public void HandleDestruction()
        {
            AddScore(_destructionScore);
            Object.Destroy(_parentTransform.gameObject);
        }

        public void AddScore(float score)
        {
            GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>().scoreCounter.AddScore(score);
        }
    }
}
