using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


namespace TowersNoDragons.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        //Main menu
        [Header("Main menu")]
        [SerializeField] private string loadLevel;
        [SerializeField] private string loadTutorial;

        //Volume
        [Header("Volume")]
        [SerializeField] private TMP_Text volumeValue = null;
        [SerializeField] private Slider volumeSlider = null;
        [SerializeField] private float defaultVol = 0.5f;


        //Graphics
        [Header("Graphics")]
        [SerializeField] private Slider brightnessSlider = null;
        [SerializeField] private TMP_Text brightnessTextValue = null;
        [SerializeField] private float defaultBrightness = 1;

        //Resolution
        [Header("Resolution")]
        [SerializeField] private TMP_Dropdown resDropDown;

        //Quality
        private int qualityLevel;
        private float brightnessLevel;
        private Resolution[] resolutions;

        private void Start()
        {
            resolutions = Screen.resolutions;
            resDropDown.ClearOptions();


            List<string> options = new List<string>();

            int currResIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currResIndex = i;
                }
            }

            resDropDown.AddOptions(options);
            resDropDown.value = currResIndex;
            resDropDown.RefreshShownValue();

        }

        public void SetReslution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void PlayButton()
        {
            SceneManager.LoadScene(loadLevel);
        }

        public void TutorialButton()
        {
            SceneManager.LoadScene(loadTutorial);
        }

        public void QuitButton()
        {
            Application.Quit();
        }

        public void SetVol(float vol)
        {
            AudioListener.volume = vol;
            volumeValue.text = vol.ToString("0.0");
        }

        public void ApplyChanges()
        {
            PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        }

        public void ResetToDefault(string MenuType)
        {
            if (MenuType == "Audio")
            {
                AudioListener.volume = defaultVol;
                volumeSlider.value = defaultVol;
                volumeValue.text = defaultVol.ToString("0.0");
                ApplyChanges();
            }
        }

        public void SetBrightness(float brightness)
        {
            brightnessLevel = brightness;
            brightnessTextValue.text = brightness.ToString("0.0");
        }

        public void SetQuality(int qualityIndex)
        {
            qualityLevel = qualityIndex;
        }

        public void GraphicsApply()
        {
            PlayerPrefs.SetFloat("masterBrightness", brightnessLevel);//save brightness

            PlayerPrefs.SetInt("masterQuality", qualityLevel);//save quality

        }
    }
}


