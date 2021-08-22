using UnityEngine;
using UnityEngine.UI;

namespace ColorSwitch
{
    public class PlayerSpriteSelectionItem : MonoBehaviour, IObserver
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image playerSprite;

        private PlayerSpriteChoice _playerSpriteChoice;
        private ISubject _subject;

        public void Init(Sprite sprite, PlayerSpriteChoice playerSpriteChoice, ISubject subject)
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
            backgroundImage.color = Color.gray;
        }

        public void SetAsDeselected()
        {
            backgroundImage.color = Color.black;
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