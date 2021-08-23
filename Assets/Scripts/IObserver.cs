using UnityEngine;

namespace ColorSwitch
{
    public interface IObserver<in T> where T : Object
    {
        void Receive(T objectObserving);
    }
}