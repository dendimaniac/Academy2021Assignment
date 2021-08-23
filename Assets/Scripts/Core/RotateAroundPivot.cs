using System.Collections;
using UnityEngine;

namespace ColorSwitch.Core
{
    public class RotateAroundPivot : MonoBehaviour
    {
        [SerializeField] private float rotateTime;
        [SerializeField] private bool shouldRotateInPositiveDirection = true;

        private int _rotateDirection;
        private WaitForSeconds _timeBetweenEachRotate;

        private void Awake()
        {
            _rotateDirection = shouldRotateInPositiveDirection ? 1 : -1;
            _timeBetweenEachRotate = new WaitForSeconds(rotateTime / 360f);
        }

        private void Start()
        {
            StartCoroutine(StartRotate());
        }

        private IEnumerator StartRotate()
        {
            while (true)
            {
                transform.Rotate(Vector3.forward, _rotateDirection * 1);
                yield return _timeBetweenEachRotate;
            }
        }
    }
}