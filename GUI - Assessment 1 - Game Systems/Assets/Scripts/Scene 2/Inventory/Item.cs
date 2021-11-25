using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    #region Variables
    private int _id;
    //Display Name
    private string _name;
    // Display Description
    private string _description;
    //amount - Stackability
    private int _amount;
    //Price - Value
    private int _value;
    //Dispalce Icon
    private Texture2D _icon;
    //mesh
    private GameObject _mesh;
    //type
    private ItemTypes _type;
    //Basic Examoke Stats
    private int _heal;
    private int _armour;
    private int _damage;
    #endregion
    #region Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public Texture2D IconName
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject MeshName
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Armor
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    #endregion

}
    public enum ItemTypes
    {
        Armour,
        Weapon,
        Potion,
        Money,
        Quest,
        Food,
        Ingredients,
        Craftable,
        Misc,

    }

    // Start is called before the first frame update
   