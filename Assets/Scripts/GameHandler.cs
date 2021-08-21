using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private PlayerDiedEventChannel playerDiedEventChannel;

        private bool _isPlayerDead;
        
        private void Awake()
        {
            playerDiedEventChannel.PlayerDied += OnPlayerDied;
        }

        private void Start()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }

        private void Update()
        {
            if (!_isPlayerDead) return;
            
            if (!Input.GetMouseButtonDown(0)) return;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void OnPlayerDied(PlayerController obj)
        {
            _isPlayerDead = true;
        }

        private void OnDestroy()
        {
            playerDiedEventChannel.PlayerDied -= OnPlayerDied;
        }
    }
}