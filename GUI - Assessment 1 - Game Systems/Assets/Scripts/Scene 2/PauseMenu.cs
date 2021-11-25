using System.Collections;
using System.Collections.Generic;
using static System.Console;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
        public AudioMixer masterAudio;
    public AudioMixer buttonAudio;
    public GameObject buttonSounds;

    public static bool isPaused;
        public GameObject _PauseMenu;
        public static bool _IsOptions;
        public static bool _DisplayOptions;
        public static bool _Audio;
        public static bool _KeyBindings;
        public float volumeMaster, buttonVolume;

        public GameObject OptionsImg;
        public Dropdown Resolutions;
        public Resolution[] resolutionsOfTheComputer;
        public Toggle FullScreen;
        public GameObject OptionsEmpty;
        public GameObject EmptyAudio;
        public GameObject KeyBindEpmty;

        // Start is called before the first frame update
        void Start()
        {
            UnPaused();
            isPaused = false;
            _PauseMenu.gameObject.SetActive(false);

            OptionsImg.gameObject.SetActive(false);
            OptionsEmpty.gameObject.SetActive(false);
            EmptyAudio.gameObject.SetActive(false);
            KeyBindEpmty.gameObject.SetActive(false);

            masterAudio.SetFloat("Master Volume", -20);
            buttonAudio.SetFloat("Button Volume", -0);

            if (Resolutions != null)
            {
                resolutionsOfTheComputer = Screen.resolutions;
                Resolutions.ClearOptions();
                List<string> resolutionOptions = new List<string>();
                int currentScreenResolution = 0;
                for (int i = 0; i < resolutionsOfTheComputer.Length; i++)
                {
                    string option = resolutionsOfTheComputer[i].width + "x" + resolutionsOfTheComputer[i].height;
                    resolutionOptions.Add(option);
                    if (resolutionsOfTheComputer[i].width == Screen.currentResolution.width && resolutionsOfTheComputer[i].height == Screen.currentResolution.height)
                    {
                        currentScreenResolution = i;
                    }

                }
                Resolutions.AddOptions(resolutionOptions);
                Resolutions.value = currentScreenResolution;
                Resolutions.RefreshShownValue();
            }
            else
            {
                Debug.LogWarning("SCRUB ATTACH THE DROP DOWN!!!!!!!");
            }
        }
    public void DisplayOptionsButton()
    {
        _DisplayOptions = !_DisplayOptions;
        if (_DisplayOptions)
        {
            _DisplayOptions = true;

        }
        else
        {
            if (_DisplayOptions == true)
            {
                _DisplayOptions = false;
            }
        }
        //if you click the audio then display turns off
        _Audio = false;
        _KeyBindings = false;
        buttonMusic();
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutionsOfTheComputer[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void AudioButton()
    {
        _Audio = !_Audio;
        if (_Audio)
        {
            _Audio = true;

        }
        else
        {
            if (_Audio == true)
            {
                _Audio = false;
            }
        }
        //if you click the Audio then options turn off
        _DisplayOptions = false;
        _KeyBindings = false;
        buttonMusic();


    }
    public void MasterVolumeAudioSliderExample(float myFloat)
    {
        masterAudio.SetFloat("Master Volume", myFloat);

    }
    public void ButtonVolumeAudioSlider(float buttonSlider)
    {
        buttonAudio.SetFloat("Button Volume", buttonSlider);

    }

    public void Paused()//When oaysed us triggered
        {
            //stop out time
            Time.timeScale = 0;
            // free out coursor
            Cursor.lockState = CursorLockMode.Confined;
            //see out coursor
            Cursor.visible = true;
            _PauseMenu.gameObject.SetActive(true);
            isPaused = true;
        }
    public void OptionsButton()
    {
      
        _IsOptions = true;
        Debug.Log("options button pushed");
        buttonMusic();
    }
    public void UnPaused()
        {
            //unoayse out game 

            //start time
            Time.timeScale = 1;
            //lock out corsor
            Cursor.lockState = CursorLockMode.Locked;
            //hide our cursor 
            Cursor.visible = false;
            _PauseMenu.gameObject.SetActive(false);
            isPaused = false;
        }
        public void ReturnButton()
        {
            UnPaused();
            MainMenu.mainMenu.buttonMusic();
        }
    
    public void KeyBindingsButton()
    {

        _KeyBindings = !_KeyBindings;
        if (_KeyBindings)
        {
            _KeyBindings = true;

        }
        else
        {
            if (_KeyBindings == true)
            {
                _KeyBindings = false;
            }
        }
        _Audio = false;
        _DisplayOptions = false;
        buttonMusic();
    }

    public void LoadButton()
        {
            MainMenu.mainMenu.buttonMusic();
        }
        public void SaveGame()
        {
            MainMenu.mainMenu.buttonMusic();
        }
        public void MainMenuButton()
        {
            SceneManager.LoadScene(1);
            MainMenu.mainMenu.buttonMusic();
        }

        public void QuitButton()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        public void BackButtonOptions()
        {
            _IsOptions = false;
            buttonMusic();

        }
    public void buttonMusic()
    {
        if (GameObject.FindGameObjectWithTag("Clicked"))
        {
            GameObject.FindGameObjectWithTag("Clicked").GetComponent<AudioSource>().Play();
        }
        //if we dont have an object in the scene tagged clicked
        if (!GameObject.FindGameObjectWithTag("Clicked"))
        {
            //spawn in an object that is tagged clicked so that it exsists and this can never run again based of the if statement it is contained it 
            //why because i only run when i dont exists but now i do
            Instantiate(buttonSounds);
            //set audio volume

        }
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {


                if (isPaused == false)
                {
                    Paused();
                    isPaused = true;
                }


                if (!isPaused == true)
                {
                    UnPaused();
                    isPaused = false;

                }


            }
        #region OptionsMenu
        //options menu if statment for the manin to options
        if (_IsOptions == true)
        {
            OptionsImg.gameObject.SetActive(true);
        }
        if (_IsOptions == false)
        {
            OptionsImg.gameObject.SetActive(false);

        }
        #endregion

        #region DisOptions
        //dispaly options turn on when click and go away when click or audio clicked
        if (_DisplayOptions == true)
        {
            OptionsEmpty.gameObject.SetActive(true);
        }
        if (_DisplayOptions == false)
        {
            OptionsEmpty.gameObject.SetActive(false);

        }
        #endregion

        #region AudioOpt
        //audio options show when clicked or go away when click or display is clicked. 
        if (_Audio == true)
        {
            EmptyAudio.gameObject.SetActive(true);
        }
        if (_Audio == false)
        {
            EmptyAudio.gameObject.SetActive(false);

        }
        #endregion
        if (_KeyBindings == true)
        {
            KeyBindEpmty.gameObject.SetActive(true);
        }
        if (_KeyBindings == false)
        {
            KeyBindEpmty.gameObject.SetActive(false);

        }
    }
}

