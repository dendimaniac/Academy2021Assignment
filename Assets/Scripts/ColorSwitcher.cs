using UnityEngine;

namespace ColorSwitch
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ColorSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioClip pickupClip;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        private ColorSwitcherPool _colorSwitcherPool;

        public void Init(ColorSwitcherPool colorSwitcherPool)
        {
            _colorSwitcherPool = colorSwitcherPool;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;

            playerController.SwitchNewPlayerColor();
            soundEffectEventChannel.RequestSoundEffect(pickupClip);
            _colorSwitcherPool.ReturnToPool(this);
        }
    }
}