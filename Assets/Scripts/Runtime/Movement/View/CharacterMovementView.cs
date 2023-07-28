using System;
using System.Collections;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class CharacterMovementView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _line;
        [SerializeField] private int _dotsCount = 6;

        private const int Offset = 1;
        private IMovement _movement;

        public void Initialize(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _line.positionCount = _dotsCount + Offset;
            StartCoroutine(RenderLine());
        }

        private IEnumerator RenderLine()
        {
            while (true)
            {
                Vector3 linePosition = _movement.Position + Vector2.left * _dotsCount;
                _line.SetPosition(0, linePosition);
                _line.SetPosition(_line.positionCount - 1, _movement.Position);

                for (int i = 1; i < _dotsCount; i++)
                {
                    linePosition += Vector3.right;
                    _line.SetPosition(i, linePosition);
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
    }
}