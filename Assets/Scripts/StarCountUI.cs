using TMPro;
using UnityEngine;

namespace ColorSwitch
{
    public class StarCountUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text starCountText;
        [SerializeField] private CanvasGroup starCountCanvasGroup;
        [Range(0, 1f)] [SerializeField] private float fadeAmount;
        [SerializeField] private StarPickedUpEventChannelSO starPickedUpEventChannel;
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;

        private int _currentStarCount;

        private void Awake()
        {
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
            playerDiedEventChannel.PlayerDied += OnPlayerDied;
        }

        private void OnStarPickedUp(Vector3 _)
        {
            ++_currentStarCount;
            starCountText.text = $"{_currentStarCount}";
        }

        private void OnPlayerDied(PlayerController obj)
        {
            starCountCanvasGroup.alpha = fadeAmount;
        }

        private void OnDestroy()
        {
            starPickedUpEventChannel.StarPickedUp -= OnStarPickedUp;
            playerDiedEventChannel.PlayerDied -= OnPlayerDied;
        }
    }
}