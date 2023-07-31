using System.Collections;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnSeconds = 1.5f;
        [SerializeField] private Obstacle _prefab;
        [SerializeField] private Transform[] _spawnPoints;

        private int _lastCreatedSpawnPointIndex;
        
        public void Initialize()
        {
            StartCoroutine(StartCreate());
        }

        private IEnumerator StartCreate()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnSeconds);
                Create();
                Create();
            }
        }

        private void Create()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        
            if (_lastCreatedSpawnPointIndex == spawnPointIndex)
                spawnPointIndex = _spawnPoints.Length - 1;
            
            Vector3 spawnPosition = _spawnPoints[spawnPointIndex].position;
            Instantiate(_prefab, spawnPosition, Quaternion.identity);
            _lastCreatedSpawnPointIndex = spawnPointIndex;
        }
    }
}