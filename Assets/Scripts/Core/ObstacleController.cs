using System.Collections.Generic;
using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Core
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private Transform endpointTransform;
        [SerializeField] private Star star;
        [SerializeField] protected List<ObstacleColorSection> obstacleColorSectionList;
        [SerializeField] private StarPickedUpEventChannelSO starPickedUpEventChannel;
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;

        public Vector3 EndpointPosition => endpointTransform.position;

        public virtual void Init(GameColor expectedGameColor)
        {
            star.Init(starPickedUpEventChannel);
            foreach (var obstacleColorSection in obstacleColorSectionList)
            {
                obstacleColorSection.Init(playerDiedEventChannel);
            }
        }
    }
}