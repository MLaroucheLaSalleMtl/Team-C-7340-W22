using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowersNoDragons.SceneManagement
{
    public class TutorialSceneHandler : MonoBehaviour
    {
        [SerializeField] private GameObject firstMessagePanel;
        [SerializeField] private string secondScene;

        void Start()
        {
            Time.timeScale = 0f;
            firstMessagePanel.SetActive(true);
            
        }

        public void LoadTutorialScene2()
        {
            SceneManager.LoadScene(secondScene);
        }

    }
}

