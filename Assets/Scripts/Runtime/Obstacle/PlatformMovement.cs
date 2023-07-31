using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void Update()
        {
            var characterPosition = _character.transform.position;
            transform.position = new Vector3(characterPosition.x, transform.position.y, transform.position.z);
        }
    }
}