using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YandexTestTask.Gameplay
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private float _timeToReachPosition = 1.4f;
        [SerializeField] private float _distanceToMove = 1.5f;
        [SerializeField] private float _timeToWaitNextMove = 0.45f;
        [SerializeField] private float _speed = 4.5f;
        
        private readonly Vector2[] _directions = 
        {
            Vector2.up,
            Vector2.down,
        };
        
        private void Start()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                Vector3 direction = _directions[Random.Range(0, _directions.Length)];
                yield return StartCoroutine(Move(direction));
                yield return new WaitForSeconds(_timeToWaitNextMove);
                yield return StartCoroutine(Move(-direction));
            }
        }

        private IEnumerator Move(Vector3 direction)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            
            while (time < _timeToReachPosition)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, startPosition.y, 0) + direction * _distanceToMove, time / _timeToReachPosition);
                yield return null;
            }
        }
    }
}