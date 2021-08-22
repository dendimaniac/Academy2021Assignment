using UnityEngine;

namespace ColorSwitch
{
    public class OffCameraPlayerKiller : MonoBehaviour
    {
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;

            playerDiedEventChannel.RaiseEvent(playerController);
            Destroy(other.gameObject);
        }
    }
}