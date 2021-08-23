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
        private GameColor _lastGameColor;
        private Vector3 _nextSpawnPosition;
        private Vector3 _obstaclesOffset;

        private void Awake()
        {
            _nextSpawnPosition = initialSpawnPosition.position;
            _obstaclesOffset = new Vector3(0, distanceBetweenObstacles, 0);
            
            starPickedUpEventChannel.StarPickedUp += OnStarPickedUp;
        }

        public void SpawnInitialObstacles(GameColor initialPlayerColor)
        {
            _lastGameColor = initialPlayerColor;
            for (var i = 0; i < initialObstacleCount; i++)
            {
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            var randomObstacleToSpawn = GetRandomObstacle();
            var spawnedObstacle = Instantiate(randomObstacleToSpawn, _nextSpawnPosition, Quaternion.identity);
            spawnedObstacle.Init(_lastGameColor);
            var colorSwitcherPosition = spawnedObstacle.EndpointPosition + _obstaclesOffset;
            var colorSwitcher = colorSwitcherPool.Get(null);
            colorSwitcher.Init(colorSwitcherPool, _lastGameColor);
            colorSwitcher.transform.position = colorSwitcherPosition;
            colorSwitcher.gameObject.SetActive(true);
            _lastGameColor = colorSwitcher.GameColorToApply;
            _nextSpawnPosition = colorSwitcherPosition + _obstaclesOffset;
        }
        
        private void OnStarPickedUp(Vector3 starPosition, int scoreGained)
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