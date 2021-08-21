using UnityEngine;

namespace ColorSwitch
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Star : MonoBehaviour
    {
        [SerializeField] private ParticleSystem starCollected;

        private Vector3 OwnPosition => transform.position;
        
        private StarPickedUpEventChannel _starPickedUpEventChannel;

        public void Init(StarPickedUpEventChannel starPickedUpEventChannel)
        {
            _starPickedUpEventChannel = starPickedUpEventChannel;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;

            Instantiate(starCollected, OwnPosition, Quaternion.identity);
            _starPickedUpEventChannel.RaiseEvent(OwnPosition);
            Destroy(gameObject);
        }
    }
}