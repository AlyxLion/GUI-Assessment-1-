using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script can be found in the Component section under the option Scrub Haus/NPC Scripts/Linear Dialogue
[AddComponentMenu("Scrub Haus/NPC Scripts/Linear Dialogue")]
public class LinearDlg : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDlg;
    //array for text for our dialogue
    public string[] dlgText;
    //index for our current line of dialogue
    public int index;
    //name of this specific NPC
    public new string name;
    //text to replace the ONGUI stuff
    public Text _dlgText;
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDlg)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            //GUI.Box(new Rect(0,MainMenu.scr.y *6,Screen.width,MainMenu.scr.y*3),name+": "+dlgText[index]);
            //if not at the end of the dialogue 
            if (index < dlgText.Length-1)
            {
                //next button allows us to skip forward to the next line of dialogue
                if (true)//(GUI.Button(new Rect(MainMenu.scr.x * 15,MainMenu.scr.y * 8.5f,MainMenu.scr.x,MainMenu.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            //else we are at the end
           else
            {            
                //the Bye button allows up to end our dialogue
                if (false)//(GUI.Button(new Rect(MainMenu.scr.x * 15, MainMenu.scr.y * 8.5f, MainMenu.scr.x, MainMenu.scr.y * 0.5f), "Bye."))
                {
                    //close the dialogue box
                    showDlg = false;
                    //set index back to 0 
                    index = 0;
                    //allow mouselook to be turned back on
                    //get the movement on the character and turn that back on
                    //lock the mouse cursor
                    //set the cursor to being invisible
                }

            }
        }
    }
    #endregion
}
