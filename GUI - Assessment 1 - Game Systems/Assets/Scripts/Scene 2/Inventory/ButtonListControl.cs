using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script makes the list of buttons that will sort the inventory items it will gen buttons from ButtonListButtons script from the templet button on canvase
// the script is on canvas/Inventory/inventory scroll itemtypes/scroll view/
public class ButtonListControl : MonoBehaviour
{
    //makes the private object seen
    [SerializeField]
    private GameObject ButtonTemplate; //allows the button templet made with the attached script to be attached to the game objects script inspector.

    //the string of typeNames as a array that is limitted to 10 
    public string[] typeNames = new string[10] { "All", "Armour", "Trinket", "Weapon", "Potion", "Food", "Ingredient", "Craftable", "Quest", "Misc" };
    //is public so in the inspector we can see what the current sorttype is, is a string because it keeps changing. 
    public string sortType;
    //allows the the creation of a list of game object running at the name buttons
    private List<GameObject> buttons;
    //makes a way for current clicked sting to be seen in inventory controls 
    private InventroyControls invCon;
    //passes a string to inventory controles that can then be converted to a string in inventory controles
    public string sortTypeClick;

    

    void Start()
    {
        //On start the string sortType has a current Value as defalut of "ALL"
        sortType = "All";
        #region other code
        /*buttons = new List<GameObject>();
        if (buttons.Count >0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }
        for (int i = 0; i < typeNames.Length; i++)
        {
            sortType = typeNames[i];
            GameObject button = Instantiate(ButtonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText(" " + typeNames[i]);

            button.transform.SetParent(ButtonTemplate.transform.parent, false);
        }*/
        #endregion
        //call listupdate to start making buttons
        ListUpdate();
    }
    //takes the string data passed from the buttonlistbutton script onclick of the button and the text string data from the button mytextstring is a public string from buttonlistbutton
    public void ButtonClicked(string myTextString)
    {
       // SendToInvCon();
        //tells the inspector that a buttonlistbutton was click and ensure that buttons data was passed back to this script
        Debug.Log("buttonList " + myTextString);
        //changes sorttype to = the name of the button pushed.
        sortType = myTextString;
        //sorttypeclick is a public string in this script that will take this scrips button string data and push it on to inventory controls.       
        //sortTypeClick = sortType;
        //sortTypeClick = myTextString;

        //invCon.SortTypeClick(sortTypeClick);
        //calls the method so that the string can be passed to inventoryCortols Script.
        SendToInvCon();
    }
    /// <summary>
    /// I could probs just have buttonlistbutton send the data stright to inventory controls and bypass this scrip all together hmmmmm.
    /// </summary>
    // this method that is call from buttonclicked is to send on the current clicked string data to inventory controls so it can gen diffrent buttons for the invtory Items to be seen.
    public void SendToInvCon()
    {
        sortTypeClick = sortType;
        //takes the string data from sorttype that is then copied by sortTypeClick and sends it to inventory controls who will then copy it to use that string data in generating buttons based on that string data.
        invCon.SortTypeClick(sortTypeClick);
    }
    //makes buttons on start as it was called.
    public void ListUpdate()
    {
        //buttons is a new collection of game objects
        buttons = new List<GameObject>();
        //if buttons exist 
        if (buttons.Count > 0)
        {
            //for every gameobject now asigned the verible button that is in the collection buttons
            foreach (GameObject button in buttons)
            {
                //destroy the gameobjects that is a button
                Destroy(button.gameObject);
            }
            //Clear the collection that is buttons 
            buttons.Clear();
        }
        //following the if, for a number stating at 0 represented as i and i is less then the string typeNames (.length gets the int of typenames) then it runs the loop after it moves on to the next part that is hey add value to i the loop keeps running until the middle section is met
        for (int i = 0; i < typeNames.Length; i++)
        {
            //take the gameobject now know as button in this local area and it is now a clone of buttonTemplate converted to a gameObject
            GameObject button = Instantiate(ButtonTemplate) as GameObject;
            //makes the gameobject button active as the templete was not
            button.SetActive(true);
            //the gameobject button has a component call buttonlistbutton(a script) in script the method setText is called this public menthod has a string that the text is equel now this string is equel to its self and the nameType iteration. 
            button.GetComponent<ButtonListButton>().SetText("" + typeNames[i]);
            //take the gameobject button and transform to be a child of the buttonTemplet this is the content object for the game, this well then take the buttontempte make it the parent then false is so it is not a world space transformation but a relitive to parent
            button.transform.SetParent(ButtonTemplate.transform.parent, false);

            //Took this one out as it was chanign sorttype  to the last in the arrays name to be = "Misc". this is due to it running over and over until the end of the array.
            //sortType = typeNames[i];
            //Debug.Log(" " + typeNames[i]);
        }
    }
    
}
