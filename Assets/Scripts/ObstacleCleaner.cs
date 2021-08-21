using UnityEngine;

namespace ColorSwitch
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstacleCleaner : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.GetComponent<ObstacleController>()) return;
            
            Destroy(other.gameObject);
        }
    }
}