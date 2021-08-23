using ColorSwitch.Helpers;
using ColorSwitch.Pools;
using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Core
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ColorSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioClip pickupClip;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        public GameColor GameColorToApply { get; private set; }
        
        private ColorSwitcherPool _colorSwitcherPool;

        public void Init(ColorSwitcherPool colorSwitcherPool, GameColor previousGameColor)
        {
            _colorSwitcherPool = colorSwitcherPool;
            GameColorToApply = GameColorHelper.GetRandom(previousGameColor);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.GetComponent<PlayerController>();
            if (!playerController) return;

            playerController.ApplyNewGameColor(GameColorToApply);
            soundEffectEventChannel.RequestSoundEffect(pickupClip);
            _colorSwitcherPool.ReturnToPool(this);
        }
    }
}