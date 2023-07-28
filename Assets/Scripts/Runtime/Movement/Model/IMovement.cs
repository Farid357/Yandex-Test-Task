using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public interface IMovement
    {
        Vector2 Position { get; }
        
        void Move(Vector2 direction);
    }
}