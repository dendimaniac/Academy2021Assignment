using ColorSwitch.Interfaces;
using ColorSwitch.ScriptableObjects.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSwitch.UI
{
    public class PlayerSpriteSelectionItem : MonoBehaviour, IObserver<Sprite>
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image playerSprite;

        [Header("Design settings")]
        [SerializeField] private Color selectedBackgroundColor;
        [SerializeField] private Color deselectedBackgroundColor;

        private PlayerSpriteChoiceSO _playerSpriteChoice;
        private ISubject<Sprite> _subject;

        public void Init(Sprite sprite, PlayerSpriteChoiceSO playerSpriteChoice, ISubject<Sprite> subject)
        {
            playerSprite.sprite = sprite;
            _playerSpriteChoice = playerSpriteChoice;
            _subject = subject;
            _subject.Subscribe(this);
        }

        public void Select()
        {
            _playerSpriteChoice.CurrentSpriteChoice = playerSprite.sprite;
            SetAsSelected();
            _subject.Notify(playerSprite.sprite);
        }

        public void SetAsSelected()
        {
            backgroundImage.color = selectedBackgroundColor;
        }

        public void SetAsDeselected()
        {
            backgroundImage.color = deselectedBackgroundColor;
        }

        public void Receive(Sprite newSprite)
        {
            if (newSprite == playerSprite.sprite) return;
            
            SetAsDeselected();
        }

        private void OnDisable()
        {
            _subject.Unsubscribe(this);
        }
    }
}