using System;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class Coin : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _money = 1;
        
        private IWallet _wallet;

        public void Initialize(IWallet wallet)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Character _))
            {
                _wallet.Add(_money);
                Destroy(gameObject);
            }
        }
    }
}