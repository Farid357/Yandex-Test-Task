using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YandexTestTask.Gameplay;

namespace YandexTestTask.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Factories")]
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private CoinFactory _coinFactory;
        [SerializeField] private ObstacleFactory _obstacleFactory;
        
        [Header("Views")]
        [SerializeField] private WalletView _walletView;
        
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        
        private GameLoop _gameLoop;

        private void Awake()
        {
            _playButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _playButton.gameObject.SetActive(false);
            _coinFactory.Initialize(new WalletPresenter(_walletView));
            _obstacleFactory.Initialize();

            Character character = _characterFactory.Create();
            
            _gameLoop = new GameLoop(new List<IGameLoopObject>
            {
                new Player(character),
                new GameRestart(character)
            });
        }

        private void Update()
        {
            _gameLoop?.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(StartGame);
        }
    }
}