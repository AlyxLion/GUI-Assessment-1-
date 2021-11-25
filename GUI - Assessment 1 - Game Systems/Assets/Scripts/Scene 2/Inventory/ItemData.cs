using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData 
{
    public static Item CreateItem(int ItemID)
    {
        
        #region Variables
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        string icon = "";
        string mesh = "";
        ItemTypes type = ItemTypes.Misc;
        int heal = 0;
        int armour = 0;
        int damage = 0;
        #endregion

        switch (ItemID)
        {
            #region Armour 0-99
            case 0:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                icon = "";
                mesh = "";
                type = ItemTypes.Misc;
                heal = 0;
                armour = 0;
                break;
                #endregion
                #region Weapon 100-199
                #endregion
                #region Potion 200-299
                #endregion
                #region Money 300-399
                #endregion
                #region Quest 400-499
                #endregion
                #region Food 500-599
                #endregion
                #region Ingredients 600-699
                #endregion
                #region Craftable 700-799
                #endregion
                #region misc 800-899
                #endregion
        }
        return null;
    }
     
}