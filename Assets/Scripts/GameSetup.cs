using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] private Spawner spawner;

        private void Start()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
            
            spawner.SpawnInitialObstacles();
        }
    }
}