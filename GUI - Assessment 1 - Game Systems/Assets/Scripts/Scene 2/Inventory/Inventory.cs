using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    //list
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;
    public Vector2 scrollPos;
    public string[] typeNames = new string[9] { "All", "Armour", "Weapon", "Potion", "Food", "Ingredient", "Craftable", "Quest", "Misc"};
    public string sortType ="All";
    public Transform dropLocation;
    [System.Serializable]

    public struct EquippedItems
    {
        public string slotName;
        public Transform equippedLocation;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItemSlot;

   
    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.I))
        {
            for (int i = 0; i < 34; i++)
            {
                inv.Add(ItemData.CreateItem(Random.Range(0, 3)));
            }
            
        }
#endif
        if (Input.GetKeyDown(KeyBindManager.inputKeys["Inventory"]) && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if  (showInv)
            {
                //cursor can be seen 
                Cursor.visible = true;
;                //cursor not locked
                Cursor.lockState = CursorLockMode.None;
                //time paused
                Time.timeScale = 0;
            }
            else
            {
                //cursor can not be seen
                Cursor.visible = false;
                //cursor is locked 
                Cursor.lockState = CursorLockMode.Locked;
                //time is not pasued
                Time.timeScale = 1;
            }
        }
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if (showInv && !PauseMenu.isPaused)
        {
            for (int i = 0; i < typeNames.Length; i++)
            {
                if (GUI.Button(new Rect(2.5f * MenuHandler.screen.x + i * 1.5f * MenuHandler.screen.x, 0, 1.25f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), typeNames[i]))
                {
                    sortType = typeNames[i];

                }
            }
            DisplayInv();
            if (selectedItem != null)
            {
                UseItems();
            }
        }
    
    }
    void DisplayInv()
    {
        //if we have a Type selected (filter)
        if (!(sortType == "All" || sortType == ""))
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
            //the amount of this type
            int a = 0;
            //new slot position of the Item
            int s = 0;
            //Find all items of type in our inv
            for (int i = 0; i < inv.Count; i++)
            {
                //if current element matches type
                if (inv[i].ItemType == type)
                {
                    //add to amount of this type
                    a++;
                }
            }
            //display our type that has been filtered if its under 34
            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(MenuHandler.screen.x * 0.5f, 0.25f * MenuHandler.screen.y + s * (0.25f * MenuHandler.screen.y), MenuHandler.screen.x * 3, MenuHandler.screen.y * 0.25f), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }
            }
            else
            {
                //our move position of our scroll window
                scrollPos =
                //the Start of our scroll view
                GUI.BeginScrollView(
                //our position and size of our window
                new Rect(0, 0.25f * MenuHandler.screen.y, 3.75f * MenuHandler.screen.x, 8.5f * MenuHandler.screen.y),
                //our current position in the scroll view
                scrollPos,
                //viewable area
                new Rect(0, 0, 0, a * 0.25f * MenuHandler.screen.y),
                //can we see our Horizontal bar?
                false,
                //Can we see our Vertical Bar?
                true);
#region loop inside scroll space
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(MenuHandler.screen.x * 0.5f, s * (0.25f * MenuHandler.screen.y), MenuHandler.screen.x * 3, MenuHandler.screen.y * 0.25f), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }
#endregion
                //end scroll view
                GUI.EndScrollView();
            }
        }
        //All Items are shown
        else
        {
            //if we have enough items to fit on the screen
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(MenuHandler.screen.x * 0.5f, 0.25f * MenuHandler.screen.y + i * (0.25f * MenuHandler.screen.y), MenuHandler.screen.x * 3, MenuHandler.screen.y * 0.25f), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            //we have more items then screen space
            else
            {
                //our move position of our scroll window
                scrollPos =
                //the Start of our scroll view
                GUI.BeginScrollView(
                //our position and size of our window
                new Rect(0, 0.25f * MenuHandler.screen.y, 3.75f * MenuHandler.screen.x, 8.5f * MenuHandler.screen.y),
                //our current position in the scroll view
                scrollPos,
                //viewable area
                new Rect(0, 0, 0, inv.Count * 0.25f * MenuHandler.screen.y),
                //can we see our Horizontal bar?
                false,
                //Can we see our Vertical Bar?
                true);
#region loop inside scroll space
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(MenuHandler.screen.x * 0.5f, i * (0.25f * MenuHandler.screen.y), MenuHandler.screen.x * 3, MenuHandler.screen.y * 0.25f), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
#endregion
                //end scroll view
                GUI.EndScrollView();
            }
        }

    }
    void UseItems()
    {
        //name
        GUI.Box(new Rect(4f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y, 3 * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), selectedItem.Name);
        //icon
        //GUI.Box(new Rect(4f * MenuHandler.screen.x, 0.5f * MenuHandler.screen.y, 3 * MenuHandler.screen.x, 3 * MenuHandler.screen.y), selectedItem.IconName);
        //discrption, amount, value
        GUI.Box(new Rect(4f * MenuHandler.screen.x, 3.5f * MenuHandler.screen.y, 3 * MenuHandler.screen.x, 0.75f * MenuHandler.screen.y), selectedItem.Description +"\nAmount: "+selectedItem.Amount+"\nValue: $"+selectedItem.Value);
        //switch via type
        switch (selectedItem.ItemType)
        {
            case ItemTypes.Armour:
                if(GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Wear"))
                {
                    //ware the thing
                }
                break;
            case ItemTypes.Weapon:
                if (equippedItemSlot[1].equippedItem == null || selectedItem.Name != equippedItemSlot[1].equippedItem.name)//this is cheaking the weapon and if its already equipped we shall cheack the slot
                {
                    if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Equipped"))
                    {
                        //Equip the thing
                        if (equippedItemSlot[1].equippedItem != null)
                        {
                            Destroy(equippedItemSlot[1].equippedItem);
                        }
                        equippedItemSlot[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItemSlot[1].equippedLocation);
                        equippedItemSlot[1].equippedItem.name = selectedItem.Name;
                        equippedItemSlot[1].equippedItem.GetComponent<ItemHandler>().enabled = false;
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(5.5f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Unequipped"))
                    {
                        //Equip the thing
                       Destroy(equippedItemSlot[1].equippedItem);
                       equippedItemSlot[1].equippedItem = null;
                    }
                }
                break;
            case ItemTypes.Potion:
                if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Drink"))
                {
                    //Drink the thing
                }
                break;
            case ItemTypes.Money:
                if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Use"))
                {
                    //money the thing
                }
                break;
            case ItemTypes.Craftable:;
                if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Wear"))
                {
                    //ware the thing
                }
                break;
            case ItemTypes.Food:
                if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Wear"))
                {
                    //ware the thing
                }
                break;
            case ItemTypes.Misc:
                if (GUI.Button(new Rect(4f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y), "Wear"))
                {
                    //ware the thing
                }
                break;
            

        }
        if (GUI.Button(new Rect(5.5f * MenuHandler.screen.x, 4.25f * MenuHandler.screen.y, 1.5f * MenuHandler.screen.x, 0.25f * MenuHandler.screen.y),"Discard"))
        {
            for (int i = 0; i < equippedItemSlot.Length; i++)
            {
                if (equippedItemSlot[i].equippedItem!=null && selectedItem.Name==equippedItemSlot[i].equippedItem.name)
                {
                    Destroy(equippedItemSlot[i].equippedItem);
                    equippedItemSlot[i].equippedItem = null;
                }
            }
            //spawn item at droploaction
            GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
            //apply gravity and make sure its named correctly
            itemToDrop.name = selectedItem.Name;
            itemToDrop.AddComponent<Rigidbody>().useGravity = true;
            //if the amount >1 if so reduce from list
            if(selectedItem.Amount>1)
            {
                selectedItem.Amount--;
            }
            else
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
        }
        //discard button
    }


}
