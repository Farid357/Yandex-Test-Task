using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class CharacterFactory : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField, Range(0.1f, 20f)] private float _speed = 1.5f;

        public Character Create()
        {
            IMovement movement = new TransformMovement(_character.transform, _speed);
            _character.Initialize(movement);
            return _character;
        }
    }
}