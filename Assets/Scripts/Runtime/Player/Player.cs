using System;
using UnityEngine;

namespace YandexTestTask.Gameplay
{
    public class Player : IGameLoopObject
    {
        private readonly PlayerInput _input;
        private readonly Character _character;

        public Player(Character character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));

            _input = new PlayerInput();
            _input.Enable();
        }

        public void Update(float deltaTime)
        {
            Vector2 moveDirection = _input.Movement.MoveDirection.ReadValue<Vector2>();
            Vector2 verticalDirection = moveDirection == Vector2.zero ? Vector2.down : moveDirection;
            _character.Move(verticalDirection + Vector2.right);
        }
    }
}