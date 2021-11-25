using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UICustChar : MonoBehaviour
{
    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes, clothes and armour
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes, clothes and armour textures
    public int skinIndex;
    public int hairIndex, eyesIndex, mouthIndex, clothesIndex, armourIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer characterRenderer;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes, clothes and armour textures that our lists are filling with
    public int skinMax;
    public int hairMax, eyesMax, mouthMax, clothesMax, armourMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string characterName;
    #endregion



    [Header("Character Class")]
    public CharacterClass charClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;
    public string classButton = "";



    public int statPoints = 10;
    [System.Serializable]
    public struct PointUI
    {
        public Stats.StatBlock stat;
        public Text nameDisplay;
        public GameObject plusButton;
        public GameObject minusButton;
    };
    public PointUI[] pointSystem;

    public Text pointsText;

    void TextUpdate()
    {
        pointsText.text = "Points: " + statPoints;
    }


    public void SetName(string charName)
    {
        characterName = charName;
    }

    #region Start
    //The First Frame that the Object and the Script are Active
    private void Start()
    {
        #region for loop to pull textures from file
        #region Skin
        //for loop looping from 0 to less than the max amount of the  textures we need for Skin
        for (int i = 0; i < skinMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Skin_i
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        #endregion
        #region Hair
        //for loop looping from 0 to less than the max amount of the  textures we need for Hair
        for (int i = 0; i < hairMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Hair_i
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }
        #endregion
        #region Eyes
        //for loop looping from 0 to less than the max amount of the  textures we need for Eyes
        for (int i = 0; i < eyesMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Eyes_i
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }
        #endregion
        #region Mouth
        //for loop looping from 0 to less than the max amount of the  textures we need for /Mouth
        for (int i = 0; i < mouthMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Mouth_i
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }
        #endregion
        #region Armour
        //for loop looping from 0 to less than the max amount of the  textures we need for Armour
        for (int i = 0; i < armourMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Armour_i
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            //add our temp texture that we just found to the armour List
            armour.Add(temp);
        }
        #endregion
        #region Clothes
        //for loop looping from 0 to less than the max amount of the  textures we need for Clothes
        for (int i = 0; i < clothesMax; i++)
        {
            //temp Texture2D that grabs our Textures using Resources.Load from the Character File looking for Clothes_i
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            //add our temp texture that we just found to the clothes List
            clothes.Add(temp);
        }
        #endregion
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        characterRenderer = GameObject.FindGameObjectWithTag("CharacterMesh").GetComponent<Renderer>();
        #region Set Textures on Start
        //SetTexture skin, hair, mouth, eyes, clothes, armour to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        #endregion
        #region Stat Points Setup
        //pointSystem
        TextUpdate();
        ChooseClass(0);

        for (int i = 0; i < pointSystem.Length; i++)
        {
            pointSystem[i].nameDisplay.text = pointSystem[i].stat.name + ": " + (pointSystem[i].stat.value + pointSystem[i].stat.tempValue);

            pointSystem[i].minusButton.SetActive(false);
        }
        #endregion
    }
    #endregion
    //SKINS
    public void SetTexturePos(string type)
    {
        SetTexture(type, 1);
    }
    public void SetTextureNeg(string type)
    {
        SetTexture(type, -1);
    }
    public void SetTexture(string type, int dir)
    {
        /*we need variables that exist only within this function
        these are ints index numbers, max numbers, material index 
        and Texture2D array of textures*/
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        #region Material and Values Switch
        //switch statement that is swapped by the string name of our material
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
                //end case
                break;
            #endregion
            #region Eyes
            case "Eyes":
                index = eyesIndex;
                //index is the same as our  index
                max = eyesMax;
                //max is the same as our max
                textures = eyes.ToArray();
                //textures is our  list .ToArray()
                matIndex = 2;
                //material index element number
                break;
            #endregion
            #region Mouth
            case "Mouth":
                index = mouthIndex;
                //index is the same as our  index
                max = mouthMax;
                //max is the same as our max
                textures = mouth.ToArray();
                //textures is our  list .ToArray()
                matIndex = 3;
                //material index element number
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
                //material index element number
                break;
                //break
                #endregion
        }
        #endregion
        #region Assign Direction
        //index plus equals dir
        index += dir;
        //cap our index to loop back around if it is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = characterRenderer.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        characterRenderer.materials = mat;
        #endregion
        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
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
        }
        #endregion
    }
    public void RandomTextures()
    {
        SetTexture("Skin", skinIndex = Random.Range(0, skinMax - 1));
        SetTexture("Hair", hairIndex = Random.Range(0, hairMax - 1));
        SetTexture("Mouth", mouthIndex = Random.Range(0, mouthMax - 1));
        SetTexture("Eyes", eyesIndex = Random.Range(0, eyesMax - 1));
        SetTexture("Clothes", clothesIndex = Random.Range(0, clothesMax - 1));
        SetTexture("Armour", armourIndex = Random.Range(0, armourMax - 1));
    }
    public void ResetTextures()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
    }

    //STATS
    public void ChooseClass(int classIndex)
    {
        switch (classIndex)
        {
            case 0:
                pointSystem[0].stat.value = 18;
                pointSystem[1].stat.value = 10;
                pointSystem[2].stat.value = 15;
                pointSystem[3].stat.value = 6;
                pointSystem[4].stat.value = 6;
                pointSystem[5].stat.value = 5;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                pointSystem[0].stat.value = 6;
                pointSystem[1].stat.value = 13;
                pointSystem[2].stat.value = 7;
                pointSystem[3].stat.value = 10;
                pointSystem[4].stat.value = 6;
                pointSystem[5].stat.value = 18;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                pointSystem[0].stat.value = 5;
                pointSystem[1].stat.value = 8;
                pointSystem[2].stat.value = 8;
                pointSystem[3].stat.value = 9;
                pointSystem[4].stat.value = 15;
                pointSystem[5].stat.value = 15;
                charClass = CharacterClass.Druid;
                break;
            case 3:
                pointSystem[0].stat.value = 8;
                pointSystem[1].stat.value = 15;
                pointSystem[2].stat.value = 10;
                pointSystem[3].stat.value = 15;
                pointSystem[4].stat.value = 8;
                pointSystem[5].stat.value = 4;
                charClass = CharacterClass.Monk;
                break;
            case 4:
                pointSystem[0].stat.value = 15;
                pointSystem[1].stat.value = 6;
                pointSystem[2].stat.value = 10;
                pointSystem[3].stat.value = 8;
                pointSystem[4].stat.value = 5;
                pointSystem[5].stat.value = 18;
                charClass = CharacterClass.Paladin;
                break;
            case 5:
                pointSystem[0].stat.value = 8;
                pointSystem[1].stat.value = 16;
                pointSystem[2].stat.value = 8;
                pointSystem[3].stat.value = 12;
                pointSystem[4].stat.value = 8;
                pointSystem[5].stat.value = 8;
                charClass = CharacterClass.Ranger;
                break;
            case 6:
                pointSystem[0].stat.value = 6;
                pointSystem[1].stat.value = 8;
                pointSystem[2].stat.value = 16;
                pointSystem[3].stat.value = 8;
                pointSystem[4].stat.value = 8;
                pointSystem[5].stat.value = 14;
                charClass = CharacterClass.Sorcerer;
                break;
            case 7:
                pointSystem[0].stat.value = 6;
                pointSystem[1].stat.value = 6;
                pointSystem[2].stat.value = 6;
                pointSystem[3].stat.value = 10;
                pointSystem[4].stat.value = 14;
                pointSystem[5].stat.value = 18;
                charClass = CharacterClass.Warlock;
                break;
        }
        for (int i = 0; i < pointSystem.Length; i++)
        {
            //reset points
            pointSystem[i].stat.tempValue = 0;
            statPoints = 10;
            //display changes
            pointSystem[i].nameDisplay.text = pointSystem[i].stat.name + ": " + (pointSystem[i].stat.value + pointSystem[i].stat.tempValue);
            //reset buttons
            pointSystem[i].minusButton.SetActive(false);
            pointSystem[i].plusButton.SetActive(true);
        }
    }
    public void SetPointsPos(int i)
    {
        //Change the Values
        statPoints--;
        pointSystem[i].stat.tempValue++;
        //if we have no points hide the pos button
        if (statPoints <= 0)
        {
            for (int button = 0; button < pointSystem.Length; button++)
            {
                pointSystem[button].plusButton.SetActive(false);
            }
        }
        //if we havent shown the minus button then activate
        if (pointSystem[i].minusButton.activeSelf == false)
        {
            pointSystem[i].minusButton.SetActive(true);
        }
        //update text
        pointSystem[i].nameDisplay.text = pointSystem[i].stat.name + ": " + (pointSystem[i].stat.value + pointSystem[i].stat.tempValue);
        TextUpdate();
    }
    public void SetPointsNeg(int i)
    {
        //Change the Values
        statPoints++;
        pointSystem[i].stat.tempValue--;
        //if we have no temps values hide our neg button
        if (pointSystem[i].stat.tempValue <= 0)
        {
            pointSystem[i].minusButton.SetActive(false);
        }
        //if we have points to spend show all pos buttons
        if (pointSystem[i].plusButton.activeSelf == false)
        {
            for (int button = 0; button < pointSystem.Length; button++)
            {
                pointSystem[button].plusButton.SetActive(true);
            }
        }
        //update text
        pointSystem[i].nameDisplay.text = pointSystem[i].stat.name + ": " + (pointSystem[i].stat.value + pointSystem[i].stat.tempValue);
        TextUpdate();
    }
}
