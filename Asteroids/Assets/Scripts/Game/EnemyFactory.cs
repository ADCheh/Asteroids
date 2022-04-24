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
            var asteroid = Object.Instantiate(LoadEnemyPrefab(AsteroidPrefabPath), _spawnerList[rnd.Next(_spawnerList.Count)].transform.position, Quaternion.identity);
            asteroid.GetComponent<Asteroid>().Player = _playerTransform;
        }

        public void CreateUfo()
        {
            var UFO = Object.Instantiate(LoadEnemyPrefab(UfoPrefabPath), _spawnerList[rnd.Next(_spawnerList.Count)].transform.position, Quaternion.identity);
            UFO.GetComponent<UFO>().Player = _playerTransform;
        }

        private GameObject LoadEnemyPrefab(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return prefab;
        }
    }
}
