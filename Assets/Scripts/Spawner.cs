using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private StarPickedUpEventChannelSO starPickedUpEventChannel;
        [SerializeField] private List<ObstacleController> obstacleList;
        [SerializeField] private ColorSwitcherPool colorSwitcherPool;
        [SerializeField] private Transform initialSpawnPosition;
        [SerializeField] private int initialObstacleCount;
        [SerializeField] private float distanceBetweenObstacles;

        private int _lastObstacleIndex = -1;
        private Vector3 _nextSpawnPosition;
        private Vector3 _obstaclesOffset;

        private void Awake()
        {
            _nextSpawnPosition = initialSpawnPosition.position;
            _obstaclesOffset = new Vector3(0, distanceBetweenObstacles, 0);
            
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
        }

        private void Start()
        {
            for (var i = 0; i < initialObstacleCount; i++)
            {
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            var randomObstacleToSpawn = GetRandomObstacle();
            var spawnedObstacle = Instantiate(randomObstacleToSpawn, _nextSpawnPosition, Quaternion.identity);
            var colorSwitcherPosition = spawnedObstacle.EndpointPosition + _obstaclesOffset;
            var colorSwitcher = colorSwitcherPool.Get(null);
            colorSwitcher.Init(colorSwitcherPool);
            colorSwitcher.transform.position = colorSwitcherPosition;
            colorSwitcher.gameObject.SetActive(true);
            _nextSpawnPosition = colorSwitcherPosition + _obstaclesOffset;
        }
        
        private void OnStarPickedUp(Vector3 _)
        {
            SpawnObstacle();
        }

        private ObstacleController GetRandomObstacle()
        {
            int randomObstacleIndex;
            do
            {
                randomObstacleIndex = Random.Range(0, obstacleList.Count);
            } while (randomObstacleIndex == _lastObstacleIndex);

            _lastObstacleIndex = randomObstacleIndex;
            return obstacleList[randomObstacleIndex];
        }

        private void OnDestroy()
        {
            starPickedUpEventChannel.StarPickedUp -= OnStarPickedUp;
        }
    }
}