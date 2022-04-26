using Enemies;
using Enemies.Infrastructure;
using UnityEngine;

namespace Game
{
    public class EnemySpawnController : MonoBehaviour
    {
        public Transform Player;
        
        private EnemyFactory _enemyFactory;
        private void Awake()
        {
            _enemyFactory = new EnemyFactory(Player);
        }

        private void Start()
        {
            StartCoroutine(_enemyFactory.SpawnEnemy(EnemyType.Asteroid));
            StartCoroutine(_enemyFactory.SpawnEnemy(EnemyType.Ufo));
        }
    }
}