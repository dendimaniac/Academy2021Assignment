using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class Initialization : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        }
    }
}