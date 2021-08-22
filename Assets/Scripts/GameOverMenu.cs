using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private TMP_Text highScoreText;

        [SerializeField] private StarPickedUpEventChannelSO starPickedUpEventChannel;
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;

        private int _currentScore;

        private void Awake()
        {
            playerDiedEventChannel.PlayerDied += OnPlayerDied;
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
        }

        public void TryAgain()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameScene"));
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("UI"));
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
        }

        private void OnPlayerDied(PlayerController obj)
        {
            gameOverMenu.SetActive(true);
            HighScoreManager.SaveScore(_currentScore);
            highScoreText.text = $"{HighScoreManager.GetHighScore()}";
        }
        
        private void OnStarPickedUp(Vector3 _)
        {
            ++_currentScore;
        }

        private void OnDestroy()
        {
            playerDiedEventChannel.PlayerDied -= OnPlayerDied;
            starPickedUpEventChannel.StarPickedUp -= OnStarPickedUp;
        }
    }
}