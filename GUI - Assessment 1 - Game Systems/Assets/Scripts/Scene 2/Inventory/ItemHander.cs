using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHander : MonoBehaviour
{
    public int itemID = 0;
    public ItemTypes itemType;
    public int amount = 1;

    public void OnCollection()
    {
        if (itemType == ItemTypes.Money)//are we money
        {
            Inventory.money += amount;
        }
        else if (itemType == ItemTypes.Potion||itemType==ItemTypes.Ingredients || itemType == ItemTypes.Food||itemType==ItemTypes.Ingredients||itemType==ItemTypes.Craftable)//are we stackable?
        {
            //do we have the item 
            int found = 0;
            //what is the index of that item
            int addIndex = 0;
            //Search for that info
            for (int i = 0; i < Inventory.inv.Count; i++)
            {
                if (itemID==Inventory.inv[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
            //if we have the item then increase the current Item amount by the amount 
            if (found==1)
            {
                Inventory.inv[addIndex].Amount += amount;
            }
            //if we dont have the item add the item and set the amoiunt to equal amount
            else
            {
                Inventory.inv.Add(ItemData.CreateItem(itemID));
                Inventory.inv[Inventory.inv.Count - 1].Amount = amount;
            }
        }
        else//narh?? just add
        {
            Inventory.inv.Add(ItemData.CreateItem(itemID));
        }
        Destroy(gameObject); //once added destory itemm from world
    }
}
