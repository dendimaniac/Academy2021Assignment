using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "StarPickedUpEventChannel", menuName = "Events/StarPickedUpEventChannel")]
    public class StarPickedUpEventChannelSO : ScriptableObject
    {
        public Action<Vector3> StarPickedUp;

        [SerializeField] private AudioClip starPickupClip;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        public void RaiseEvent(Vector3 starPosition)
        {
            StarPickedUp?.Invoke(starPosition);
            soundEffectEventChannel.RequestSoundEffect(starPickupClip);
        }
    }
}