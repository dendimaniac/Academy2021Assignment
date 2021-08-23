using UnityEngine;

namespace ColorSwitch.Interfaces
{
    public interface IObserver<in T> where T : Object
    {
        void Receive(T objectObserving);
    }
}