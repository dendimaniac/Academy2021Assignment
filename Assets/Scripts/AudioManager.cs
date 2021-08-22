using UnityEngine;

namespace ColorSwitch
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource soundEffectAudioSource;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        private static AudioManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
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