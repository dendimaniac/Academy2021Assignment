using UnityEngine;

namespace ColorSwitch
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(Sprite newSprite);
    }
}