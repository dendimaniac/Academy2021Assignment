using UnityEngine;
using UnityEngine.UI;

namespace ColorSwitch
{
    public class PlayerSpriteSelectionItem : MonoBehaviour, IObserver
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image playerSprite;

        [Header("Design settings")]
        [SerializeField] private Color selectedBackgroundColor;
        [SerializeField] private Color deselectedBackgroundColor;

        private PlayerSpriteChoiceSO _playerSpriteChoice;
        private ISubject _subject;

        public void Init(Sprite sprite, PlayerSpriteChoiceSO playerSpriteChoice, ISubject subject)
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