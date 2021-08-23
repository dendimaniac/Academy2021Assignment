using System.Collections;
using ColorSwitch.Pools;
using TMPro;
using UnityEngine;

namespace ColorSwitch.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScorePopup : MonoBehaviour
    {
        [Range(0, 2f)] [SerializeField] private float maxPopupVerticalAddition;
        [SerializeField] private float popupSpeed;
        [SerializeField] private float cleanupDelay;

        private TMP_Text _scoreGainedText;
        private Vector3 _maxPopupPosition;
        private ScorePopupPool _scorePopupPool;
        private WaitForSeconds _cleanupSecondsDelay;
        
        private void Awake()
        {
            _scoreGainedText = GetComponent<TMP_Text>();
            _cleanupSecondsDelay = new WaitForSeconds(cleanupDelay);
        }

        public void Init(ScorePopupPool scorePopupPool, Vector3 starPosition, int scoreGained)
        {
            _scorePopupPool = scorePopupPool;
            _maxPopupPosition = starPosition + new Vector3(0, maxPopupVerticalAddition, 0);
            transform.position = starPosition;
            _scoreGainedText.text = $"+{scoreGained}";
        }

        private void Update()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _maxPopupPosition, popupSpeed * Time.deltaTime);
            
            if (transform.position != _maxPopupPosition) return;

            StartCoroutine(WaitAndHide());
            enabled = false;
        }

        private IEnumerator WaitAndHide()
        {
            yield return _cleanupSecondsDelay;
            _scorePopupPool.ReturnToPool(this);
            enabled = true;
        }
    }
}