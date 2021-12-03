using System;
using UnityEngine;

public class Stats : Attributes
{
    //Str - crush a tomato - Brute force
    //Dex - dodge a tomato/shoot a tomato - accuracy and cat like reflexes
    //Con - eat a bad tomato - health and resistance
    //Int - knowing that a tomato is a fruit - book smart
    //Wis - wisdom is knowing not to put tomato into a fruit salad - street smart 
    //Char - the ability to sell a tomato based fruit salad
    #region Structs
    [Serializable]
    public struct StatBlock
    {
        //name of our stat
        public string name;
        //base value of our stat
        public int value;
        //buff or debuff value being applied
        public int tempValue;
        //temp value for leveling
        public int levelTempValue;
    }
    #endregion
    #region Variables
    public StatBlock[] characterStats = new StatBlock[6];
    public CharacterClass characterClass = CharacterClass.Barbarian;
    [HideInInspector]
    public CharacterRace characterRace = CharacterRace.Human;
    #endregion

}
public enum CharacterClass
{
    Barbarian,
    Bard,
    //Cleric,
    Druid,
    //Fighter,
    Monk,
    Paladin,
    Ranger,
    //Rogue,
    Sorcerer,
    Warlock,
   // Wizard
}
public enum CharacterRace
{
    Dragonborn,
    Dwarf,
    Elf,
    Gnome,
    HalfElf,
    Halfling,
    HalfOrc,
    Human,
    Tiefling
}
/*public enum CharacterClass
{
    Barbarian,
    Bard,
    Druid,
    Monk,
    Paladin,
    Ranger,
    Sorcerer,
    Warlock
}*/
