using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonToMainMenu : MonoBehaviour
{
    /*Vector2 scr;

    // Update is called once per frame
    private void OnGUI()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        BackButton();   
    }
    void BackButton()
    {    
        if(GUI.Button(new Rect(.5f * scr.x, 8 * scr.y, 1.5f * scr.x, .75f * scr.y), "Back"))
        {
            SceneManager.LoadScene(0);
        }
        if(GUI.Button(new Rect(14f * scr.x, 8 * scr.y, 1.5f * scr.x, .75f * scr.y), "Next"))
        {
            SceneManager.LoadScene(2);
        }
    }*/

    public void BackButton()
    {
        SceneManager.LoadScene(1);
    }

    public void NextButton()
    {
        SceneManager.LoadScene(2);
    }
}
