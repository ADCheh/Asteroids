using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Enemies.Infrastructure
{
    
    public partial class EnemyFactory
    {
        private List<GameObject> _spawnerList = new List<GameObject>();
        private Dictionary<EnemyType, GameObject> _enemyPrefabs = new Dictionary<EnemyType, GameObject>();

        private const string PrefabFolderPath =  "Prefabs/";

        private Transform _playerTransform;
        private System.Random rnd = new System.Random();
        
        public EnemyFactory(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            
            RegisterSpawners();
            RegisterEnemies();
        }

        private void RegisterSpawners()
        {
            foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
            {
                _spawnerList.Add(spawner);
            }
        }

        private void RegisterEnemies()
        {
            foreach (EnemyType enemyType in Enum.GetValues(typeof(EnemyType)))
            {
                string path = String.Concat(PrefabFolderPath, enemyType.ToString());
                _enemyPrefabs.Add(enemyType,LoadEnemyPrefab(path));
            }
        }

        public IEnumerator SpawnEnemy(EnemyType enemyType)
        {
            while (true)
            {
                yield return new WaitForSeconds((float) enemyType);
                CreateEnemy(enemyType);
            }
        }

        public void CreateEnemy(EnemyType enemyType)
        {
            var enemyInstance = InstantiateEnemy(enemyType);
            GivePlayerReference(enemyInstance);
        }

        private GameObject InstantiateEnemy(EnemyType enemyType)
        {
            return Object.Instantiate(
                _enemyPrefabs[enemyType],_spawnerList[rnd.Next(_spawnerList.Count)].transform.position,
                Quaternion.identity);
        }

        private GameObject LoadEnemyPrefab(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return prefab;
        }

        private void GivePlayerReference(GameObject enemy)
        {
            enemy.GetComponent<IEnemy>().Player = _playerTransform;
        }
    }
}
