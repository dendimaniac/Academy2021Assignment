using UnityEngine;

namespace ColorSwitch
{
    public class ScorePopupManager : MonoBehaviour
    {
        [SerializeField] private ScorePopupPool scorePopupPool;
        [SerializeField] private StarPickedUpEventChannel starPickedUpEventChannel;

        private void Awake()
        {
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
        }

        private void OnStarPickedUp(Vector3 starPosition)
        {
            var scorePopup = scorePopupPool.Get(transform);
            scorePopup.Init(scorePopupPool, starPosition);
            scorePopup.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            starPickedUpEventChannel.StarPickedUp -= OnStarPickedUp;
        }
    }
}