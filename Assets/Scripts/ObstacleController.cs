using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private Transform endpointTransform;
        [SerializeField] private Star star;
        [SerializeField] private List<ObstacleColorSection> obstacleColorSectionList;
        [SerializeField] private StarPickedUpEventChannel starPickedUpEventChannel;
        [SerializeField] private PlayerDiedEventChannel playerDiedEventChannel;

        public Vector3 EndpointPosition => endpointTransform.position;

        private void Awake()
        {
            star.Init(starPickedUpEventChannel);
            foreach (var obstacleColorSection in obstacleColorSectionList)
            {
                obstacleColorSection.Init(playerDiedEventChannel);
            }
        }
    }
}