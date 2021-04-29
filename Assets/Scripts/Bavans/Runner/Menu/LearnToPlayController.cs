using UnityEngine.SceneManagement;
using UnityEngine;
using Bavans.Runner.Player;

namespace Bavans.Runner.Menu
{
    public class LearnToPlayController : MonoBehaviour
    {
        public void LoadMovementScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Movement", LoadSceneMode.Single);
        }

        public void LoadRotationtScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Rotation", LoadSceneMode.Single);
        }

        public void LoadJumpScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Jump", LoadSceneMode.Single);
        }

        public void LoadMagicScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Magic", LoadSceneMode.Single);
        }

        public void LoadMenuScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
