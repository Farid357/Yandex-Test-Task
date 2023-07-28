using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YandexTestTask.Gameplay
{
    public class CoinFactory : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Coin _prefab;
        [SerializeField] private float _timeBetweenSpawn;
       
        private IWallet _wallet;

        public void Initialize(IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            StartCoroutine(Create());
        }

        private IEnumerator Create()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                Coin coin = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
                coin.Initialize(_wallet);
            }
        }
    }
}