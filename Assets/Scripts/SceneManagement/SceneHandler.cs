using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowersNoDragons.SceneManagement
{
    public class SceneHandler : MonoBehaviour
    {
        private int currentSceneIndex;

        void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Time.timeScale = 1;
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

