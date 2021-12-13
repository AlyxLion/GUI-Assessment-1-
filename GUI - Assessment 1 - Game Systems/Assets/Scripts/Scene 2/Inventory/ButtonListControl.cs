using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonTemplate;

    [SerializeField]
    public string[] typeNames = new string[10] { "All", "Armour", "Trinket", "Weapon", "Potion", "Food", "Ingredient", "Craftable", "Quest", "Misc" };
    
    public string sortType = "All";
    private List<GameObject> buttons;

    void Start()
    {
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
        ListUpdate();
    }
    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);

        
    }
    public void ListUpdate()
    {
        buttons = new List<GameObject>();
        if (buttons.Count > 0)
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
        }
    }
}
