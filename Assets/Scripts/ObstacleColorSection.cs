using UnityEngine;

namespace ColorSwitch
{
    public class ObstacleColorSection : MonoBehaviour
    {
        [SerializeField] private GameColor gameColor;
        
        private PlayerDiedEventChannel _playerDiedEventChannel;

        public void Init(PlayerDiedEventChannel playerDiedEventChannel)
        {
            _playerDiedEventChannel = playerDiedEventChannel;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;
            if (playerController.CurrentColor == gameColor) return;
            
            // _playerDiedEventChannel.RaiseEvent(playerController);
            // Destroy(playerController.gameObject);
        }
    }
}