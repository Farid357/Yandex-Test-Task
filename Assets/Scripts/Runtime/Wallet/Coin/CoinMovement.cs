using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class CoinMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.4f;

        private void Update()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }
}