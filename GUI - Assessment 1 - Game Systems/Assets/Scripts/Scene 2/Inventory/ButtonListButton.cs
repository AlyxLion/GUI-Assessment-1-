using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script gens canvas buttons from the temp button in canvas/Inventory/inventory scroll itemtypes/scroll view/viewport/content/Button
//it takes the string from buttonlistcontrol then by its direction makes each button and renames them.
public class ButtonListButton : MonoBehaviour
{
    //these are for the templet buttons text
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControl buttonControl; //allows calls to other button

    public string myTextString;

    //this is for receving the string of text that will go on each button from button list controls
    public void SetText(string textString)
    {
        //this takes the string on the temp button in its text and allows mytextstring to carry it it will change as the button changes
        myTextString = textString;
        //this is for the buttonlist controls to send to this script the string of names that the temp button will use.
        myText.text = textString;
        Debug.Log("mytextstr " + myTextString);
    }
    // when you click the button
    public void Onclick()
    {
        Debug.Log("onclicked " + myTextString);
        // when the new button that is made from the temp buttons is clicked its string name in its text will be sent back to button list control as the string. it is dynamic it changees as the button clicked changes
        //well i guess its also static like the button is made from a string but then once its made then the button is like the same right it no change but the script is run over many of the same sort of obj
        //so in a way the string from the button is static but the script is dynamic as you can only click on thing at a time so each time you do it changes that dynamic string to what ever is current yyaya
        buttonControl.ButtonClicked(myTextString);
        

    }
}
