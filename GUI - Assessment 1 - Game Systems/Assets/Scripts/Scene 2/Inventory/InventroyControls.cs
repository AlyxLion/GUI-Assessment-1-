using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventroyControls : MonoBehaviour
{
    [SerializeField]
    public static List<Item> inv = new List<Item>();
    //private List<PlayerItem> playerInventory;
    
    [SerializeField]
    private GameObject buttonInvTemplate;
    [SerializeField]
    private GridLayoutGroup gridGroup;
    public Item selectedItem;
    //public string[] typeNames = new string[10] { "All", "Armour", "Trinket", "Weapon", "Potion", "Scroll", "Food", "Ingredient", "Material", "Misc" };
    public static int money;
    //private Sprite[] iconSprites;

    //[SerializeField]
    //public ButtonListControl _sortType;

    public string currentType;

    //private ItemData itemData;

    private void Start()
    {
        currentType = "All";
        //playerInventory = new List<PlayerItem>();

        for (int i = 0; i < 64; i++)
        {
            //ItemData.CreateItem() newItem = new ();

            //Item newItem = new Item();
            //newItem.Icon = Icon[Random.Range(0, Icon.Length)];
            // icon.Icon = icon[];
            //ItemData newItem = new ItemData();
            //Item ItemData.CreateItem = new Icon();
            //_icon.Icon = _icon[ItemData.CreateItem(Random.Range(0, 703)];
            inv.Add(ItemData.CreateItem(Random.Range(0, 703)));
           
        }

        //GenInventory();


        /*ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), _sortType.sortType);
        foreach (ItemTypes types_ in itemData.Item Item )
        {
            
            Item newItem = new Item();
            //newItem.iconSprite = iconSprites[Random.Range(0, iconSprites.Length)];
            newItem.Icon = Resources.Load("Icons/" + type.ToString()) as Sprite;
            inv.Add(newItem);
        }*/

        InvItem();
    }
    //this calls the current string type from other parts.
    public void SortTypeClick(string sortTypeClick)
    {

        currentType = sortTypeClick;
        Debug.Log("invCon " + sortTypeClick);
        //updates invtory based on what is selected
        //GenInventory();
    }
    public void InvItem()
    {
        foreach (Item ItemsInv in inv)
        {
            GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<InventoryButton>().SetIcon(ItemsInv.Icon);
            newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
            Debug.Log("for if invcount working");
        }
    }
    void GenInventory()
    {
        /*foreach (Item CreateItem in inv)
        {
            GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<InventoryButton>().SetIcon(CreateItem.Icon);
            newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
        }*/
        /*foreach (ItemData CreateItem in inv)
        {
            GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<InventoryButton>().SetIcon(newItem.Icon);
            newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
        }*/
        //_sortType.sortType = _sortType.typeNames[10];
        if (!(currentType == "All")) //|| currentType == ""))
        {
            //selectedItem = inv[i];
            
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), currentType);
            Debug.Log("all working");
            //the amount of this type
            int a = 0;
            //new slot position of the Item
            //int s = 0;
            //Find all items of type in our inv

            for (int i = 0; i < inv.Count; i++)
            {
                GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
                newButton.SetActive(true);

                newButton.GetComponent<InventoryButton>().SetIcon(inv[i].Icon);
                newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
                Debug.Log("for if invcount working");
                //if current element matches type
                if (inv[i].ItemTypes == type)
                {
                    //selectedItem = inv[i];
                    a++;
                    /*foreach (ItemData CreateItem in inv)
                    {
                        GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
                        newButton.SetActive(true);

                        newButton.GetComponent<InventoryButton>().SetIcon(newItem.Icon);
                        newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
                    }*/
                    Debug.Log("for if inv[]I working");
                }
            }
            if (a <= 64)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemTypes == type)
                    {
                        
                        /*foreach (Item ItemsInv in inv)
                        {
                            GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
                            newButton.SetActive(true);

                            newButton.GetComponent<InventoryButton>().SetIcon(ItemsInv.Icon);
                            newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
                        }*/
                    }
                }
            }
            /*foreach (Item selectedItem in inv)
            {
                GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
                newButton.SetActive(true);

                newButton.GetComponent<InventoryButton>().SetIcon(selectedItem.Icon);
                newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
            }*/
            /*for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].ItemType == type)
                {
                    
                }
            }*/

            //maybe I have an update functin that cheacks what the type is and if else statements that call the function for that type and distroy items of other types when it is not within the type
            // so a funtion for armor and wepons and in update its like if type == armor call armorType() fuck then what 
            //grrr so anoyying 
        }
        else//dont filter
        {
            //if we have enough items to fit on the screen
            if (inv.Count <= 64)
            {
                //generate a button for every element in our inventory
                for (int i = 0; i < inv.Count; i++)
                {
                    selectedItem = inv[i];

                    foreach (Item selectedItem in inv)
                    {
                        GameObject newButton = Instantiate(buttonInvTemplate) as GameObject;
                        newButton.SetActive(true);

                        newButton.GetComponent<InventoryButton>().SetIcon(selectedItem.Icon);
                        newButton.transform.SetParent(buttonInvTemplate.transform.parent, false);
                        Debug.Log("else working");
                    }
                }
            }
        }
    }
    private void Update()
    {
        

        if (PauseMenu.showInv == true)
        {
            //cursor can be seen 
            Cursor.visible = true;
            ;                //cursor not locked
            Cursor.lockState = CursorLockMode.None;
            //time paused
            Time.timeScale = 0;
            //GenInventory();
        }

        if (PauseMenu.showInv == false)
        { 
            //cursor can not be seen
            Cursor.visible = false;
            //cursor is locked 
            Cursor.lockState = CursorLockMode.Locked;
            //time is not pasued
            Time.timeScale = 1;
        }
        //currentType = _sortType.sortType;
        //_sortType.sortType = 
        // _sortType.sortType = typeNames[;

    }
    /*public class PlayerItem
    {
       public Sprite iconSprite;
    }*/
}
