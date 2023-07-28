using System;
using UnityEngine.SceneManagement;

namespace YandexTestTask.Gameplay
{
    public class GameRestart : IGameLoopObject
    {
        private readonly Character _character;
        
        private bool _restarting;

        public GameRestart(Character character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public void Update(float deltaTime)
        {
            if (_character.IsDied && !_restarting)
            {
                _restarting = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}