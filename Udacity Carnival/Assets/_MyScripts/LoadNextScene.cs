using UnityEngine;
using UnityEngine.SceneManagement;

namespace _MyScripts {
    public class LoadNextScene : MonoBehaviour {
        public void LoadFollowingSceneScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }
}