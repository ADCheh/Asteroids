using System;
using System.Collections;
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
            StartCoroutine(SpawnAsteroids());
            StartCoroutine(SpawnUfo());
        }

        private IEnumerator SpawnAsteroids()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                _enemyFactory.CreateAsteroid();
            }
        }

        private IEnumerator SpawnUfo()
        {
            while (true)
            {
                yield return new WaitForSeconds(5);
                _enemyFactory.CreateUfo();
            }
        }
    }
}