using System;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "StarPickedUpEventChannel", menuName = "Events/StarPickedUpEventChannel")]
    public class StarPickedUpEventChannel : ScriptableObject
    {
        public Action<Vector3> StarPickedUp;

        public void RaiseEvent(Vector3 starPosition)
        {
            StarPickedUp?.Invoke(starPosition);
        }
    }
}