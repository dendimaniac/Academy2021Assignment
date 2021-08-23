using UnityEngine;

namespace ColorSwitch
{
    public interface ISubject<T> where T : Object
    {
        void Subscribe(IObserver<T> observer);
        void Unsubscribe(IObserver<T> observer);
        void Notify(T subject);
    }
}