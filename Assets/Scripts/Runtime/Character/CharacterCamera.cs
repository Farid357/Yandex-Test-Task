using UnityEngine;

namespace YandexTestTask.Gameplay
{
    [RequireComponent(typeof(Camera))]
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private Character _target;
        [SerializeField, Min(0.1f)] private float _followSpeed = 1.2f;
       
        private bool _isInitialized;
        
        public void Initialize()
        {
            _isInitialized = true;
        }
        
        private void LateUpdate()
        {
            if (!_isInitialized)
                return;

            Vector3 targetPosition = new Vector3(_target.transform.position.x, 0, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _followSpeed);
        }
    }
}