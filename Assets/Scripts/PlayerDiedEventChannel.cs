using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerDiedEventChannel", menuName = "Events/PlayerDiedEventChannel")]
    public class PlayerDiedEventChannel : ScriptableObject
    {
        public Action<PlayerController> PlayerDied;

        public void RaiseEvent(PlayerController playerController)
        {
            PlayerDied?.Invoke(playerController);
        }
    }
}