using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.Helpers
{
    public class Initialization : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        }
    }
}