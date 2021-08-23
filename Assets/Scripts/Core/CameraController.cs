using ColorSwitch.ScriptableObjects.EventChannels;
using UnityEngine;

namespace ColorSwitch.Core
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float moveSpeed;
        
        [SerializeField] private PlayerDiedEventChannelSO playerDiedEventChannel;
        
        private Vector3 _targetPosition;

        private void Awake()
        {
            playerDiedEventChannel.PlayerDied += OnPlayerDied;
            _targetPosition.z = transform.position.z;
        }

        private void Update()
        {
            if (playerTransform.position.y <= transform.position.y) return;

            _targetPosition.y = playerTransform.position.y;
            transform.position =
                Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
        }
        
        private void OnPlayerDied(PlayerController _)
        {
            enabled = false;
        }

        private void OnDestroy()
        {
            playerDiedEventChannel.PlayerDied -= OnPlayerDied;
        }
    }
}