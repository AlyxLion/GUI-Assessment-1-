using UnityEngine;
public class Item
{
    #region Variables
    //ID
    private int _id;
    //Name
    private string _name;
    //Description
    private string _description;
    //Amount
    private int _amount;
    //Value
    private int _value;
    //Stats
    private int _damage;
    private int _armour;
    private int _heal;
    //Icon
    private Sprite _icon;
    //Mesh
    private GameObject _mesh;
    //Type
    private ItemTypes _type;
    #endregion
    #region Properties 
    //Encapsulation 
    public int ID
    {
        get { return _id; }//read or see what _id is storing
        set { _id = value; }//Set or change _id to the value we pass through
    }
    public string Name
    {
        get { return _name; }//read or see what _name is storing
        set { _name = value; }//Set or change _name to the value we pass through
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
    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject Mesh
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Armour
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
    Trinket,
    Weapon,
    Potion,
    Scroll,
    Food,
    Ingredient,
    Material,
    Money,
    Misc
}