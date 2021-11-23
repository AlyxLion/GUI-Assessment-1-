using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject buttonSounds;
    public GameObject MainMenuImg;
    public Button Play;
    public Button Options;
    public Button Exit;
    [Space(25)]
    public GameObject PlayImg;
    public Button ConTinue;
    public Text SorryC;
    public Button LoadGame;
    public Text SorryL;
    public Button NewGame;
    public Text SorryN;
    public Button Back;
    [Space(25)]
    public GameObject OptionsImg;
    public Dropdown Resolutions;
    public Resolution[] resolutionsOfTheComputer;
    public Toggle FullScreen;
    public GameObject OptionsEmpty;
    [Space(25)]
    public Button Audio;
    public AudioMixer masterAudio;
    public GameObject music;
    public AudioMixer buttonAudio;
    public GameObject EmptyAudio;
    public Button BackOpt;
    [Space(25)]
    public GameObject KeyBindEpmty;

    [Space(25)]
    public static bool _IsPlay;
    public static bool _IsOptions;
    public static bool _DisplayOptions;
    public static bool _Audio;
    public static bool _KeyBindings;
    public float volumeMaster, buttonVolume;

    public static MainMenu mainMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Music"))
        {
            Instantiate(music);
            
            masterAudio.SetFloat("Master Volume", volumeMaster);


        }

    }
    void Start()
    {
        _IsOptions = false;
        _IsPlay = false;
        _DisplayOptions = false;
        _Audio = false;
        _KeyBindings = false;
        
        PlayImg.gameObject.SetActive(false);
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

    public void PlayButton()
    {
        
        _IsPlay = true;
        Debug.Log("yes a thing has happend");
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
    public void OptionsButton()
    {
        /*_IsOptions = !_IsOptions;
        if (_IsOptions == false)
        {
            _IsOptions = true;
        }
        if (_IsOptions == true)
        {
            _IsOptions = false;
        }*/

        //this  is to call the options menu from main
        _IsOptions = true;
        Debug.Log("options button pushed");
        buttonMusic();
    }
    #region PlayMenus
    public void BackButtonPlay()
    {
        _IsPlay = false;
        buttonMusic();
    }
    public void ContinueButtonG()
    {
        SorryC.text = " Sorry about this but you dont have a game to contiune with";
        Invoke("TextUpdateCon", 10f);
        Debug.Log("Continue button pushed");
        buttonMusic();

    }
    void TextUpdateCon()
    {
        SorryC.text = "   ";
    }
    public void LoadGameButton()
    {
        SorryL.text = " Sorry about this but you cant Load a game as you have no saves";
        Invoke("TextUpdateLoad", 10f);
        buttonMusic();
    }
    void TextUpdateLoad()
    {
        SorryL.text = "   ";
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(2);
        buttonMusic();
    }
    void TextUpdateNew()
    {
        SorryN.text = "   ";
    }
    #endregion

    #region OptionsButtons
    public void BackButtonOptions()
    {
        _IsOptions = false;
        buttonMusic();

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
    #endregion
    public void MasterVolumeAudioSliderExample(float myFloat)
    {
        masterAudio.SetFloat("Master Volume",myFloat);

    }
    public void ButtonVolumeAudioSlider(float buttonSlider)
    {
        buttonAudio.SetFloat("Button Volume",buttonSlider);

    }
    #region Exit 
    public void ExitButtonBro()
    {
        buttonMusic();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion



    // Update is called once per frame
    void Update()
    {
        #region PlayMenu
        //Play Main to Play options. 
        if (_IsPlay == true)
        {
            PlayImg.gameObject.SetActive(true);
        }
        if(_IsPlay == false)
        {
            PlayImg.gameObject.SetActive(false);
            
        }
        #endregion

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
