using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerDiedEventChannel", menuName = "Events/PlayerDiedEventChannel")]
    public class PlayerDiedEventChannelSO : ScriptableObject
    {
        public Action<PlayerController> PlayerDied;

        public void RaiseEvent(PlayerController playerController)
        {
            PlayerDied?.Invoke(playerController);
        }
    }
}