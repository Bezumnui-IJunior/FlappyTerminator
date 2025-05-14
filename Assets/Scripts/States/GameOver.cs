using UnityEngine;
using UnityEngine.UI;
using View;

namespace States
{
    public class GameOver : State, IGameOver
    {
        [SerializeField] private Freezer _freezer;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private Button _playButton;

        public void Occupy()
        {
            _freezer.Freeze();
            _gameOverView.Enable();
            _playButton.onClick.AddListener(OnPlayButton);
        }

        public void Exit()
        {
            _gameOverView.Disable();
            _playButton.onClick.RemoveListener(OnPlayButton);
        }

        [ContextMenu("Exit")]
        private void OnPlayButton()
        {
            ChangeState<IGame>();
        }
    }
}