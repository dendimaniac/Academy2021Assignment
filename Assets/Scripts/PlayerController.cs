using UnityEngine;

namespace ColorSwitch
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float jumpForce;
        [SerializeField] private GameColorToColorMapSO gameColorToColorMap;
        [SerializeField] private PlayerSpriteChoiceSO playerSpriteChoice;
        
        [Space]
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private SoundEffectEventChannelSO soundEffectEventChannel;

        public GameColor CurrentColor { get; private set; }
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            SetInitialPlayerSprite();
        }

        public void ApplyNewGameColor(GameColor newGameColor)
        {
            CurrentColor = newGameColor;
            spriteRenderer.color = gameColorToColorMap.ColorMapDictionary[newGameColor];
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
            soundEffectEventChannel.RequestSoundEffect(jumpClip);
        }

        private void SetInitialPlayerSprite()
        {
            spriteRenderer.sprite = playerSpriteChoice.CurrentSpriteChoice;
        }
    }
}