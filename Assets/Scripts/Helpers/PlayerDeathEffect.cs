using ColorSwitch.Core;
using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Helpers
{
    public class PlayerDeathEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem playerDeath;
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;

        private void Awake()
        {
            playerDiedEventChannel.PlayerDied += OnPlayerDied;
        }

        private void OnPlayerDied(PlayerController playerController)
        {
            Instantiate(playerDeath, playerController.transform.position, Quaternion.identity);
        }

        private void OnDestroy()
        {
            playerDiedEventChannel.PlayerDied -= OnPlayerDied;
        }
    }
}