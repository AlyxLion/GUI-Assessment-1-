using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationSet : Stats
{
    #region Variables
    [Header("Character Name")]
    //name of our character that the user is making
    public string characterName;
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>(); //1
    public List<Texture2D> mouth = new List<Texture2D>(); //2
    public List<Texture2D> eyes = new List<Texture2D>(); //3
    public List<Texture2D> hair = new List<Texture2D>(); //4
    public List<Texture2D> clothes = new List<Texture2D>();//5
    public List<Texture2D> armour = new List<Texture2D>(); //6
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int mouthIndex, eyesIndex, hairIndex, clothesIndex, armourIndex, helmIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    // public MeshRenderer characterMesh;
    public Renderer character;
    public Renderer helm;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int mouthMax, eyesMax, hairMax, clothesMax, armourMax;
    [Header("Other")]
    public bool raceDrop;
    public string raceDropDisplay = "Select Race";
    public bool classDrop;
    public string classDropDisplay = "Select Class";

    public Vector2 scrollPosRace, scrollPosClass;
    public int bonusStats = 6;
    public string[] materialNames = new string[7] { "Skin", "Mouth", "Eyes", "Hair", "Clothes", "Armour", "Helm" };
    public string[] attributeName = new string[3] { "Health", "Stamina", "Mana" };
    public string[] statName = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };


    #endregion

    #region Start
    //in start we need to set up the following
    private void Start()
    {
        for (int i = 0; i < attributeName.Length; i++) // 3
        {
            attributes[i].name = attributeName[i];
        }
        for (int i = 0; i < statName.Length; i++) // 6
        {
            characterStats[i].name = statName[i];
        }
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            mouth.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            eyes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            hair.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            clothes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            armour.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<Renderer>();
        helm = GameObject.Find("cap").GetComponent<Renderer>();
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        SetTexture("Helm", 0);
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing

    public void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        Renderer curRend = new Renderer();
        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
        switch (type)
        {
            #region Skin
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number
                matIndex = 1;
                curRend = character;
                //end case
                break;
            #endregion
            #region Mouth
            //case Mouth
            case "Mouth":
                //index is the same as our Mouth index
                index = mouthIndex;
                //max is the same as our Mouth max
                max = mouthMax;
                //textures is our Mouth list .ToArray()
                textures = mouth.ToArray();
                //material index element number
                matIndex = 2;
                curRend = character;

                //end case
                break;
            #endregion
            #region Eyes
            //case Eyes
            case "Eyes":
                //index is the same as our Eyes index
                index = eyesIndex;
                //max is the same as our Eyes max
                max = eyesMax;
                //textures is our Eyes list .ToArray()
                textures = eyes.ToArray();
                //material index element number
                matIndex = 3;
                curRend = character;
                //end case
                break;
            #endregion
            #region Hair
            case "Hair":
                index = hairIndex;
                //index is the same as our  index
                max = hairMax;
                //max is the same as our  max
                textures = hair.ToArray();
                //textures is our  list .ToArray()
                matIndex = 4;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Clothes
            case "Clothes":
                index = clothesIndex;
                //index is the same as our  index
                max = clothesMax;
                //max is the same as our max
                textures = clothes.ToArray();
                //textures is our  list .ToArray()
                matIndex = 5;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Armour
            case "Armour":
                index = armourIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 6;
                curRend = character;
                //material index element number
                break;
            //break
            case "Helm":
                index = helmIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 1;
                curRend = helm;
                //material index element number
                break;
                //break
                #endregion
        }
        #endregion       
        //outside our switch statement
        #region Assign Direction
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = curRend.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        curRend.materials = mat;
        #endregion
        //create another switch that is goverened by the same string name of our material
        #region Set Material Switch
        switch (type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Helm":
                helmIndex = index;
                break;
        }
        #endregion
    }
    #endregion

    #region Class and Stats
    //create a switch statment that holds the base stats for each class
    /*void ChooseClass(int classIndex)
    {
        //15, 14, 13, 12, 10, 8
        switch (classIndex)
        {
            case 0:
                characterStats[0].value = 13;//str
                characterStats[1].value = 11;//dex
                characterStats[2].value = 12;//con
                characterStats[3].value = 10;//int
                characterStats[4].value = 6;//wis
                characterStats[5].value = 8;//char
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                characterStats[0].value = 6;//str
                characterStats[1].value = 10;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 12;//int
                characterStats[4].value = 11;//wis
                characterStats[5].value = 13;//char
                charClass = CharacterClass.Bard;
                break;
            case 2:
                characterStats[0].value = 10;//str
                characterStats[1].value = 6;//dex
                characterStats[2].value = 11;//con
                characterStats[3].value = 8;//int
                characterStats[4].value = 13;//wis
                characterStats[5].value = 12;//char
                charClass = CharacterClass.Cleric;
                break;
            case 3:
                characterStats[0].value = 6;//str
                characterStats[1].value = 12;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 11;//int
                characterStats[4].value = 13;//wis
                characterStats[5].value = 10;//char
                charClass = CharacterClass.Druid;
                break;
            case 4:
                characterStats[0].value = 13;//str
                characterStats[1].value = 11;//dex
                characterStats[2].value = 12;//con
                characterStats[3].value = 8;//int
                characterStats[4].value = 6;//wis
                characterStats[5].value = 10;//char
                charClass = CharacterClass.Fighter;
                break;
            case 5:
                characterStats[0].value = 10;//str
                characterStats[1].value = 13;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 11;//int
                characterStats[4].value = 12;//wis
                characterStats[5].value = 6;//char
                charClass = CharacterClass.Monk;
                break;
            case 6:
                characterStats[0].value = 12;//str
                characterStats[1].value = 10;//dex
                characterStats[2].value = 11;//con
                characterStats[3].value = 6;//int
                characterStats[4].value = 8;//wis
                characterStats[5].value = 13;//char
                charClass = CharacterClass.Paladin;
                break;
            case 7:
                characterStats[0].value = 13;//str
                characterStats[1].value = 12;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 10;//int
                characterStats[4].value = 11;//wis
                characterStats[5].value = 6;//char
                charClass = CharacterClass.Ranger;
                break;
            case 8:
                characterStats[0].value = 6;//str
                characterStats[1].value = 13;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 10;//int
                characterStats[4].value = 11;//wis
                characterStats[5].value = 12;//char
                charClass = CharacterClass.Rogue;
                break;
            case 9:
                characterStats[0].value = 6;//str
                characterStats[1].value = 8;//dex
                characterStats[2].value = 13;//con
                characterStats[3].value = 12;//int
                characterStats[4].value = 11;//wis
                characterStats[5].value = 10;//char
                charClass = CharacterClass.Sorcerer;
                break;
            case 10:
                characterStats[0].value = 8;//str
                characterStats[1].value = 6;//dex
                characterStats[2].value = 12;//con
                characterStats[3].value = 13;//int
                characterStats[4].value = 11;//wis
                characterStats[5].value = 10;//char
                charClass = CharacterClass.Warlock;
                break;
            case 11:
                characterStats[0].value = 8;//str
                characterStats[1].value = 10;//dex
                characterStats[2].value = 8;//con
                characterStats[3].value = 13;//int
                characterStats[4].value = 12;//wis
                characterStats[5].value = 11;//char
                charClass = CharacterClass.Wizard;
                break;
        }
    }*/
    #endregion
    #region Race and Bonus
    void ChooseRace(int raceIndex)
    {
        // = 6
        switch (raceIndex)
        {
            case 0:
                characterStats[0].tempValue = 3;//str
                characterStats[1].tempValue = 0;//dex
                characterStats[2].tempValue = 0;//con
                characterStats[3].tempValue = 0;//int
                characterStats[4].tempValue = 0;//wis
                characterStats[5].tempValue = 3;//char
                characterRace = CharacterRace.Dragonborn;
                break;
            case 1:
                characterStats[0].tempValue = 3;//str
                characterStats[1].tempValue = 0;//dex
                characterStats[2].tempValue = 3;//con
                characterStats[3].tempValue = 0;//int
                characterStats[4].tempValue = 0;//wis
                characterStats[5].tempValue = 0;//char
                characterRace = CharacterRace.Dwarf;
                break;
            case 2:
                characterStats[0].tempValue = 0;//str
                characterStats[1].tempValue = 4;//dex
                characterStats[2].tempValue = 0;//con
                characterStats[3].tempValue = 1;//int
                characterStats[4].tempValue = 0;//wis
                characterStats[5].tempValue = 1;//char
                characterRace = CharacterRace.Elf;
                break;
            case 3:
                characterStats[0].tempValue = 1;//str
                characterStats[1].tempValue = 1;//dex
                characterStats[2].tempValue = 0;//con
                characterStats[3].tempValue = 4;//int
                characterStats[4].tempValue = 0;//wis
                characterStats[5].tempValue = 0;//char
                characterRace = CharacterRace.Gnome;
                break;
            case 4:
                characterStats[0].tempValue = 0;//str
                characterStats[1].tempValue = 2;//dex
                characterStats[2].tempValue = 1;//con
                characterStats[3].tempValue = 0;//int
                characterStats[4].tempValue = 0;//wis
                characterStats[5].tempValue = 3;//char
                characterRace = CharacterRace.HalfElf;
                break;
            case 5:
                characterStats[0].tempValue = 0;//str
                characterStats[1].tempValue = 3;//dex
                characterStats[2].tempValue = 1;//con
                characterStats[3].tempValue = 0;//int
                characterStats[4].tempValue = 1;//wis
                characterStats[5].tempValue = 1;//char
                characterRace = CharacterRace.Halfling;
                break;
            case 6:
                characterStats[0].tempValue = 6;//str
                characterStats[1].tempValue = 0;//dex
                characterStats[2].tempValue = 3;//con
                characterStats[3].tempValue = 0;//int
                characterStats[4].tempValue = -2;//wis
                characterStats[5].tempValue = -1;//char
                characterRace = CharacterRace.HalfOrc;
                break;
            case 7:
                characterStats[0].tempValue = 1;//str
                characterStats[1].tempValue = 1;//dex
                characterStats[2].tempValue = 1;//con
                characterStats[3].tempValue = 1;//int
                characterStats[4].tempValue = 1;//wis
                characterStats[5].tempValue = 1;//char
                characterRace = CharacterRace.Human;
                break;
            case 8:
                characterStats[0].tempValue = 0;//str
                characterStats[1].tempValue = 0;//dex
                characterStats[2].tempValue = 0;//con
                characterStats[3].tempValue = 2;//int
                characterStats[4].tempValue = 1;//wis
                characterStats[5].tempValue = 3;//char
                characterRace = CharacterRace.Tiefling;
                break;
        }
    }
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void SaveCharacter()
    {
        //SetInt for skins
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);
        PlayerPrefs.SetInt("HelmIndex", helmIndex);
        //SetString CharacterName, class, race
        PlayerPrefs.SetString("CharacterName", characterName);
        //PlayerPrefs.SetString("CharacterClass", charClass.ToString());
        PlayerPrefs.SetString("CharacterRace", characterRace.ToString());
        //int loop stats
        for (int i = 0; i < characterStats.Length; i++)
        {
            PlayerPrefs.SetInt(characterStats[i].name,(characterStats[i].value + characterStats[i].tempValue + characterStats[i].levelTempValue));
        }
    }
    #endregion

    #region OnGUI
    private void OnGUI()        //Function for our GUI elements
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
        //create a loop that will help with shuffling your GUI elements under eachother
        #region Buttons and Display for Custom
        for (int i = 0; i < materialNames.Length; i++)
        {
            //GUI button on the left of the screen with the contence <
            if (GUI.Button(new Rect(0.25f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "<"))
            {
                //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
                SetTexture(materialNames[i], -1);
            }
            //GUI Box or Lable on the left of the screen with the contence 
            GUI.Box(new Rect(0.75f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 1.5f * scr.x, 0.5f * scr.y), materialNames[i]);

            //GUI button on the left of the screen with the contence >
            if (GUI.Button(new Rect(2.25f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), ">"))
            {
                //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
                SetTexture(materialNames[i], 1);
            }
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this - happens auto coz loop
        }
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.25f * scr.x, 2.5f * scr.y + materialNames.Length * (0.5f * scr.y), 1.25f * scr.x, 0.5f * scr.y), "Random"))
        {
            skinIndex = Random.Range(0, skinMax);
            hairIndex = Random.Range(0, hairMax);
            mouthIndex = Random.Range(0, mouthMax);
            eyesIndex = Random.Range(0, eyesMax);
            clothesIndex = Random.Range(0, clothesMax);
            armourIndex = Random.Range(0, armourMax);
            helmIndex = Random.Range(0, armourMax);
            SetTexture("Skin", 0);
            SetTexture("Hair", 0);
            SetTexture("Mouth", 0);
            SetTexture("Eyes", 0);
            SetTexture("Clothes", 0);
            SetTexture("Armour", 0);
            SetTexture("Helm", 0);
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.5f * scr.x, 2.5f * scr.y + materialNames.Length * (0.5f * scr.y), 1.25f * scr.x, 0.5f * scr.y), "Reset"))
        {
            //index = 0 is resetting the index value we are using and incrementing with so we are forcing everything to update and the index values to reset
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Helm", helmIndex = 0);
        }
        #endregion
        #region Character Name
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        //move down the screen or place somewhere else
        characterName = GUI.TextField(new Rect(0.25f * scr.x, 2.5f * scr.y + (materialNames.Length + 1) * (0.5f * scr.y), 2.5f * scr.x, 0.5f * scr.y), characterName, 32);


        #endregion
        #region Select Class
        //button for toggling dropdown
        if (GUI.Button(new Rect(12.75f * scr.x, 2.5f * scr.y, 2 * scr.x, 0.5f * scr.y), classDropDisplay))
        {
            classDrop = !classDrop;
        }
        //if dropdown - scroll view that displays our classes as selectable buttons
        if (classDrop)
        {
            float listSize = System.Enum.GetNames(typeof(CharacterClass)).Length;
            scrollPosClass = GUI.BeginScrollView(new Rect(12.75f * scr.x, 3f * scr.y, 2 * scr.x, 4f * scr.y), scrollPosClass, new Rect(0, 0, 0, listSize * 0.5f * scr.y));
            GUI.Box(new Rect(0, 0, 1.75f * scr.x, listSize * 0.5f * scr.y), "");
            for (int i = 0; i < listSize; i++)
            {
                if (GUI.Button(new Rect(0, 0.5f * scr.y * i, 1.75f * scr.x, 0.5f * scr.y), System.Enum.GetNames(typeof(CharacterClass))[i]))
                {
                    //ChooseClass(i);
                    classDropDisplay = System.Enum.GetNames(typeof(CharacterClass))[i];
                    classDrop = false;
                }
            }
            GUI.EndScrollView();
        }
        #endregion
        #region Select Race
        //button for toggling dropdown
        if (!classDrop)
        {
            if (GUI.Button(new Rect(12.75f * scr.x, 3f * scr.y, 2 * scr.x, 0.5f * scr.y), raceDropDisplay))
            {
                raceDrop = !raceDrop;
            }
            //if dropdown - scroll view that displays our races as selectable buttons
            if (raceDrop)
            {
                float listSize = System.Enum.GetNames(typeof(CharacterRace)).Length;
                scrollPosRace = GUI.BeginScrollView(new Rect(12.75f * scr.x, 3.5f * scr.y, 2 * scr.x, 3.5f * scr.y), scrollPosRace, new Rect(0, 0, 0, listSize * 0.5f * scr.y));
                GUI.Box(new Rect(0, 0, 1.75f * scr.x, listSize * 0.5f * scr.y), "");
                for (int i = 0; i < listSize; i++)
                {
                    if (GUI.Button(new Rect(0, 0.5f * scr.y * i, 1.75f * scr.x, 0.5f * scr.y), System.Enum.GetNames(typeof(CharacterRace))[i]))
                    {
                        ChooseRace(i);
                        raceDropDisplay = System.Enum.GetNames(typeof(CharacterRace))[i];
                        raceDrop = false;
                    }
                }
                GUI.EndScrollView();
            }
        }

        #endregion
        #region Add Points
        // stats - display stats
        if (!classDrop && !raceDrop)
        {
            //Box for points to spend
            GUI.Box(new Rect(12.75f * scr.x, 3.5f * scr.y, 2 * scr.x, 0.5f * scr.y), "Points: " + bonusStats);
            // + and - buttons on either side of a box/label
            for (int i = 0; i < characterStats.Length; i++)
            {
                //-
                //if our points are below 6 && the level temp value is above 0
                if (bonusStats < 6 && characterStats[i].levelTempValue > 0)
                {
                    if (GUI.Button(new Rect(12.25f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "-"))
                    {
                        //remove points from level temp and add points to bonus stats
                        bonusStats++;
                        characterStats[i].levelTempValue--;
                    }
                }
                //type
                //display total stats and stat name
                GUI.Box(new Rect(12.75f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 2f * scr.x, 0.5f * scr.y), characterStats[i].name + ": " + (characterStats[i].value + characterStats[i].tempValue + characterStats[i].levelTempValue));
                //+
                //if bonus stats are above 0
                if (bonusStats > 0)
                {
                    if (GUI.Button(new Rect(14.75f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "+"))
                    {
                        //remove points from bonus stats and add points to level temp
                        bonusStats--;
                        characterStats[i].levelTempValue++;
                    }
                }
            }
        }
        #endregion
        #region Save & Play
        // display button if named/Class/Race/Points
        if (characterName != "" && classDropDisplay != "Select Class" && raceDropDisplay != "Select Race" && bonusStats == 0)
        {
            //GUI Button called Save and Play 
            if (GUI.Button(new Rect(7f * scr.x, 7.5f * scr.y, 2f * scr.x, 0.5f * scr.y), "Save and Play"))
            {
                //this button will run the save function 
                SaveCharacter();
                //and also load into the game level
                SceneManager.LoadScene(2);
            }
        }       
        #endregion
    }
    #endregion
}
