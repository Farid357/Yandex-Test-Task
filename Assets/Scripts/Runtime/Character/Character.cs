using System;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class Character : MonoBehaviour
    {
        private IMovement _movement;

        public void Initialize(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public bool IsDied { get; private set; }

        public void Move(Vector2 direction)
        {
            _movement.Move(direction);
        }

        public void Die()
        {
            if (IsDied)
                throw new InvalidOperationException("Character is already died!");

            IsDied = true;
        }
    }
}