using UnityEngine;

namespace ColorSwitch
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Star : MonoBehaviour
    {
        [SerializeField] private ParticleSystem starCollected;
        [SerializeField] private int scoreToGain = 1;

        private Vector3 OwnPosition => transform.position;
        
        private StarPickedUpEventChannelSO _starPickedUpEventChannel;

        public void Init(StarPickedUpEventChannelSO starPickedUpEventChannel)
        {
            _starPickedUpEventChannel = starPickedUpEventChannel;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;

            Instantiate(starCollected, OwnPosition, Quaternion.identity);
            _starPickedUpEventChannel.RaiseEvent(OwnPosition, scoreToGain);
            Destroy(gameObject);
        }
    }
}