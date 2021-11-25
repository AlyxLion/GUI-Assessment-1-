using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{
    [System.Serializable]
    public struct Screenlayout
    {
        public float x;
        public float y;
        [Range(0, 4000)]
        public float across;
        [Range(0, 4000)]
        public float down;
    }
    [Header("Screen Display")]
    public static Screenlayout screen;
    public bool showOptions;
    [Header("Audio")]
    [Tooltip("Refrence to unity Audio Mizer")]
    public AudioMixer audi;
    public float volumeMaster, volumeSFX, volumeMusic;
    [Tooltip("Reference to our Audio Source prefab")]
    public GameObject music;
    [Header("Options Tabs")]
    public string[] idList;
    public int currentOption;
    public bool isMuted = true;
    public string muteCurrent;
    [Header("Resolution")]
    public Resolution[] resolutions;
    public string[] resolutionName;
    public bool showResOptions;
    public string resDropDownLabel = "Resolution";
    public string fullScreenToggleName = "Windows";
    public Vector2 scrollPosition = Vector2.zero;
    [Header("Keybind Setup")]
    public static Dictionary<string, KeyCode> inputKeys = new Dictionary<string, KeyCode>();
    [Serializable]
    public struct KeySetup
    {
        public string keyName;
        public string defaultKey;
        public string tempKey;
    }
    [Header("KeyBind")]
    public KeySetup[] keySetUp;
    [Tooltip("This Doent get filled by us, it helps us wor out what key is selected")]
    public KeySetup currentKey;
    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Music"))
        {
            Instantiate(music);
        }
        #region Resolution 
        //grab all the resolutions of out screen and add them to a list
        resolutions = Screen.resolutions;
        resolutionName = new string[resolutions.Length];
        //for every resolution create the display name
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionName[i] = resolutions[i].width + "x" + resolutions[i].height;
        }
        #endregion
        #region KeyBinds
        if (inputKeys.Count <= 0)
        {

            //For loop to add the keys to the Dictionary with Save or Defualt depending on load 
            for (int i = 0; i < keySetUp.Length; i++)//for all the Keys in our base set up array
            {
                //add Key according to the saved string or default
                inputKeys.Add(keySetUp[i].keyName, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keySetUp[i].keyName, keySetUp[i].defaultKey)));
                //Parse Method is used to convert the string represebtatuib if 1 data type to another
                //Int32.Parse = ini into its 32 Bits 
                //Enum.parse = enum
                Debug.Log(keySetUp[i].keyName + ":" + keySetUp[i].defaultKey);
            }
            #endregion
        }

    }

    private void OnGUI()
    {
        screen.x = Screen.width / 16;
        screen.y = Screen.height / 9;

        AspectRatioGrid();//Will always be showing unless "if" statement 
        if (showOptions) //If show options is ture 
        {
            LayoutOptionsScreen(); //play our options 
        }
        else//if show options is fales
        {
            //Display our menu
            LayoutMenuScreen();//display menu layout
        }
    }
    void AspectRatioGrid()
    {
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(x * screen.x, y * screen.y, screen.x, screen.y), "");
                GUI.Label(new Rect(x * screen.x, y * screen.y, screen.x, screen.y), x + "," + y);
            }
        }
    }
    void LayoutMenuScreen()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        //Background
        GUI.Box(new Rect(3 * screen.x, 2 * screen.y, 10 * screen.x, 5 * screen.y), "Background");
        //Title
        GUI.Box(new Rect(4 * screen.x, 2.25f * screen.y, 8 * screen.x, 0.5f * screen.y), "Title");
        //Play
        if (GUI.Button(new Rect(4 * screen.x, 3 * screen.y, 8 * screen.x, 0.5f * screen.y), "Play"))
        {
            SceneManager.LoadScene(1);
        }
        //Options
        if (GUI.Button(new Rect(4 * screen.x, 3.75f * screen.y, 8 * screen.x, 0.5f * screen.y), "Options"))
        {
            showOptions = true;
        }        
        //Exit
        if (GUI.Button(new Rect(6 * screen.x, 5 * screen.y, 4 * screen.x, 1.75f * screen.y), "Exit"))
        {
#if UNITY_EDITOR // developer code only in unity doesnt build into the game
            UnityEditor.EditorApplication.isPlaying = false;// makes unity look like its is quitting
#endif
            Application.Quit();//quits application 
        }

    }
    void LayoutOptionsScreen()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        //Background
        GUI.Box(new Rect(3 * screen.x, 2 * screen.y, 10 * screen.x, 5 * screen.y), "Background");
        //Title
        GUI.Box(new Rect(4 * screen.x, 2.25f * screen.y, 8 * screen.x, 0.5f * screen.y), "Options");
        #region
        for (int buttonIndexNumber = 0; buttonIndexNumber < idList.Length; buttonIndexNumber++)
        {
            if (GUI.Button(new Rect(4 * screen.x + (buttonIndexNumber * 2 * screen.x), 3 * screen.y, 2 * screen.x, 0.5f * screen.y), idList[buttonIndexNumber]))
            {
                currentOption = buttonIndexNumber;
                scrollPosition = Vector2.zero;
            }
        }
        switch (currentOption)
        {
            case 0:
                #region Audio
                audi.SetFloat("MasterVolume", volumeMaster = GUI.HorizontalSlider(new Rect(4 * screen.x, 3.75f * screen.y, 2 * screen.x, 0.25f * screen.y), volumeMaster, -80, 20));
                audi.SetFloat("VolumeSFX", volumeSFX = GUI.HorizontalSlider(new Rect(4 * screen.x, 4.15f * screen.y, 2 * screen.x, 0.25f * screen.y), volumeSFX, -80, 20));
                audi.SetFloat("VolumeMusic", volumeMusic = GUI.HorizontalSlider(new Rect(4 * screen.x, 4.55f * screen.y, 2 * screen.x, 0.25f * screen.y), volumeMusic, -80, 20));
                #endregion
                break;
            case 1:
                #region Resolution Settings
                if (GUI.Button(new Rect(6 * screen.x, 3.75f * screen.y, 2 * screen.x, 0.25f * screen.y), resDropDownLabel))
                {
                    showResOptions = !showResOptions;
                    //if true become fules
                    //if fules become true
                }
                if (showResOptions)
                {
                    //create a background
                    GUI.Box(new Rect(6 * screen.x, 4 * screen.y, 3 * screen.x, 4f * screen.y), "");
                    //create a scroll view
                    scrollPosition = GUI.BeginScrollView(new Rect(6 * screen.x, 4f * screen.y, 3f * screen.x, 4f * screen.y), scrollPosition, new Rect(0, 0, 0, 0.5f * screen.y * resolutions.Length), false, true);
                    //fill the scroll view with the buttons
                    for (int i = 0; i < resolutions.Length; i++)
                    {
                        if (GUI.Button(new Rect(0, i * 0.5f * screen.y, 2.75f * screen.x, 0.5f * screen.y), resolutionName[i]))
                        {
                            //set out resolution to the seclected resolution
                            Screen.SetResolution(resolutions[i].width, resolutions[i].height, Screen.fullScreen);
                            //close dropdown
                            showResOptions = false;
                        }
                    }
                    //for every elements create a button according to our arrays 
                    //if button pressed set our resolution to the selected resolution 
                    //close dropdown
                    GUI.EndScrollView();
                }
                #endregion 
                break;
            case 2:
                #region KeyBindings
                for (int i = 0; i < keySetUp.Length; i++)
                {
                    if (GUI.Button(new Rect(8 * screen.x, 3.75f * screen.y, 2 * screen.x, .025f * screen.y), keySetUp[i].keyName))
                    {
                        currentKey.keyName = keySetUp[i].keyName;
                    }
                }
                if (currentKey.keyName != null)
                {
                    Keybinds();
                }
                #endregion

                break;
            case 3:

                break;
            default:
                currentOption = 0;
                break;
        }
        if (GUI.Button(new Rect(4 * screen.x, 6 * screen.y, 1.5f * screen.x, .75f * screen.y), "Back"))
        {
            showOptions = false;

        }
        #endregion
        //Mute Button
        if (GUI.Button(new Rect(10.5f*screen.x, 6*screen.y, 1.5f*screen.x, .75f*screen.y), muteCurrent))
        {
            isMuted = !isMuted;
            if (isMuted)
            {         
               muteCurrent = "Unmute";
               audi.SetFloat("MasterVolume", -80);

            }
            else
            {
                muteCurrent = "Mute";
                audi.SetFloat("MasterVolume", 0);
            }

          
        }
    }
    void SaveKey()
    {
        foreach (var key in inputKeys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
    void Keybinds()
    {
        string newKey = "";
        Event e = Event.current;
        if (currentKey.keyName != null)
        {
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            if (newKey != "")//if new key isnt empty
            {
                inputKeys[currentKey.keyName] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey);
                //the Above changes out Key in the Dictionary to the Key we Just Pressed
                Debug.Log(currentKey.keyName + ":" + newKey);
                currentKey.keyName = null;// Reset and wait 
            }
        }
    }

}

