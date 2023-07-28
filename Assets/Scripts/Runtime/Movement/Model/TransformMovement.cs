using System;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class TransformMovement : IMovement
    {
        private readonly Transform _transform;
        private readonly float _speed;
        
        public TransformMovement(Transform transform, float speed)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _speed = speed;
        }

        public Vector2 Position => _transform.position;

        public void Move(Vector2 direction)
        {
            _transform.Translate( direction * Time.deltaTime * _speed);
        }
    }
}