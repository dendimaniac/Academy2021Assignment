using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class PlayerSpriteSelectionUI : MonoBehaviour, ISubject
    {
        [SerializeField] private PlayerSpriteSelectionItem playerSpriteSelectionItemPrefab;
        [SerializeField] private PlayerSpriteChoiceSO playerSpriteChoice;

        private readonly List<IObserver> _observers = new List<IObserver>();

        private void Start()
        {
            foreach (var sprite in playerSpriteChoice.allPossibleSprites)
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

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
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