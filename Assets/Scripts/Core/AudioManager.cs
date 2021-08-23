using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Core
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource soundEffectAudioSource;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        private void Awake()
        {
            soundEffectEventChannel.RequestedSoundEffectClip += OnRequestedSoundEffectClip;
        }

        private void OnRequestedSoundEffectClip(AudioClip newSoundEffectClip)
        {
            soundEffectAudioSource.PlayOneShot(newSoundEffectClip);
        }

        private void OnDestroy()
        {
            soundEffectEventChannel.RequestedSoundEffectClip -= OnRequestedSoundEffectClip;
        }
    }
}