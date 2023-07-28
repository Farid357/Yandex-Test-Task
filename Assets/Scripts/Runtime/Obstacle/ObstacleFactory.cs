using System.Collections;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnSeconds = 1.5f;
        [SerializeField] private Obstacle _prefab;
        [SerializeField] private Transform[] _spawnPoints;

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
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            Instantiate(_prefab, spawnPosition, Quaternion.identity);
        }
    }
}