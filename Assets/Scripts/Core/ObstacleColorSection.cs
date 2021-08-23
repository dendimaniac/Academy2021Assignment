using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Core
{
    public class ObstacleColorSection : MonoBehaviour
    {
        [SerializeField] private GameColor gameColor;
        
        private PlayerDiedEventChannelSO _playerDiedEventChannel;

        public void Init(PlayerDiedEventChannelSO playerDiedEventChannel)
        {
            _playerDiedEventChannel = playerDiedEventChannel;
        }

        public void OverrideDefaultGameColor(GameColor newGameColor)
        {
            gameColor = newGameColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;
            if (playerController.CurrentColor == gameColor) return;
            
            _playerDiedEventChannel.RaiseEvent(playerController);
            Destroy(playerController.gameObject);
        }
    }
}