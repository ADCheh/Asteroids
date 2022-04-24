using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    
    public class EnemyFactory
    {
        private List<GameObject> _spawnerList = new List<GameObject>();

        private const string AsteroidPrefabPath =  "Prefabs/Asteroid";
        private const string UfoPrefabPath =  "Prefabs/UFO";

        private Transform _playerTransform;

        private System.Random rnd = new System.Random();
        

        public EnemyFactory(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            
            foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
            {
                _spawnerList.Add(spawner);
            }
        }

        public void CreateAsteroid()
        {
            var asteroid = InstantiateEnemy(AsteroidPrefabPath);
            GivePlayerReference(asteroid);
        }

        public void CreateUfo()
        {
            var UFO = InstantiateEnemy(UfoPrefabPath);
            GivePlayerReference(UFO);
        }

        private GameObject InstantiateEnemy(string path)
        {
            return Object.Instantiate(
                LoadEnemyPrefab(path),_spawnerList[rnd.Next(_spawnerList.Count)].transform.position,
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
