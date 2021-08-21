using UnityEngine;

namespace ColorSwitch
{
    public class ObstacleRotate : MonoBehaviour
    {
        [SerializeField] private float rotateTime;
        [SerializeField] private bool shouldRotateInPositiveDirection = true;

        private int _rotateDirection;

        private void Awake()
        {
            _rotateDirection = shouldRotateInPositiveDirection ? 1 : -1;
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward, _rotateDirection * 360f / rotateTime);
        }
    }
}