using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject _PauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        UnPaused();
        isPaused = false;
        _PauseMenu.gameObject.SetActive(false);
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
            
            
            if (!isPaused ==true)
            {
                UnPaused();
                isPaused = false;

            }
               
            
        }
    }
}
