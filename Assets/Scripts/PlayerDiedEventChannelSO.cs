using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerDiedEventChannel", menuName = "Events/PlayerDiedEventChannel")]
    public class PlayerDiedEventChannelSO : ScriptableObject
    {
        public Action<PlayerController> PlayerDied;
        
        [SerializeField] private AudioClip playerDiedClip;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        public void RaiseEvent(PlayerController playerController)
        {
            PlayerDied?.Invoke(playerController);
            soundEffectEventChannel.RequestSoundEffect(playerDiedClip);
        }
    }
}