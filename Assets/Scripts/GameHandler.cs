using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameHandler : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}