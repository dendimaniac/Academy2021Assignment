using ColorSwitch.Pools;
using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.UI
{
    public class ScorePopupManager : MonoBehaviour
    {
        [SerializeField] private ScorePopupPool scorePopupPool;
        [SerializeField] private StarPickedUpEventChannelSO starPickedUpEventChannel;

        private void Awake()
        {
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
        }

        private void OnStarPickedUp(Vector3 starPosition, int scoreGained)
        {
            var scorePopup = scorePopupPool.Get(transform);
            scorePopup.Init(scorePopupPool, starPosition, scoreGained);
            scorePopup.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            starPickedUpEventChannel.StarPickedUp -= OnStarPickedUp;
        }
    }
}