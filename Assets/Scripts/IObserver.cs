using UnityEngine;

namespace ColorSwitch
{
    public interface IObserver
    {
        void Receive(Sprite newSprite);
    }
}