using System.Collections.Generic;
using ColorSwitch.Interfaces;
using ColorSwitch.ScriptableObjects.Data;
using UnityEngine;

namespace ColorSwitch.UI
{
    public class PlayerSpriteSelectionUI : MonoBehaviour, ISubject<Sprite>
    {
        [SerializeField] private PlayerSpriteSelectionItem playerSpriteSelectionItemPrefab;
        [SerializeField] private PlayerSpriteChoiceSO playerSpriteChoice;

        private readonly List<IObserver<Sprite>> _observers = new List<IObserver<Sprite>>();

        private void Start()
        {
            foreach (var sprite in playerSpriteChoice.AllPossibleSprites)
            {
                var spawnedSelectionItem = Instantiate(playerSpriteSelectionItemPrefab, transform);
                spawnedSelectionItem.Init(sprite, playerSpriteChoice, this);

                if (sprite != playerSpriteChoice.CurrentSpriteChoice)
                {
                    spawnedSelectionItem.SetAsDeselected();
                    continue;
                }
                
                spawnedSelectionItem.SetAsSelected();
            }
        }

        public void Subscribe(IObserver<Sprite> observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver<Sprite> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Sprite newSprite)
        {
            foreach (var observer in _observers)
            {
                observer.Receive(newSprite);
            }
        }
    }
}