using UnityEngine;

namespace YandexTestTask.Gameplay
{
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Character character))
            {
                character.Die();
            }
        }
    }
}