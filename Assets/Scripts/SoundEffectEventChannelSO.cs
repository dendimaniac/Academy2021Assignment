using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "SoundEffectEventChannel", menuName = "Events/SoundEffectEventChannel")]
    public class SoundEffectEventChannelSO : ScriptableObject
    {
        public Action<AudioClip> RequestedSoundEffectClip;

        public void RequestSoundEffect(AudioClip newSoundEffectClip)
        {
            RequestedSoundEffectClip?.Invoke(newSoundEffectClip);
        }
    }
}