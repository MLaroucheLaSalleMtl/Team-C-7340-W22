using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowersNoDragons.SceneManagement
{
    public class TutorialSceneHandler : MonoBehaviour
    {
        [SerializeField] private GameObject firstMessagePanel;

        void Start()
        {
            firstMessagePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void LoadTutorialScene2()
        {
            SceneManager.LoadScene("TutorialScene_2");
        }

    }
}

