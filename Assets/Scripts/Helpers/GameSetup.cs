using ColorSwitch.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.Helpers
{
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Spawner spawner;

        private void Start()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);

            var initialPlayerColor = GameColorHelper.GetRandom(GameColor.None);
            playerController.ApplyNewGameColor(initialPlayerColor);
            spawner.SpawnInitialObstacles(initialPlayerColor);
        }
    }
}