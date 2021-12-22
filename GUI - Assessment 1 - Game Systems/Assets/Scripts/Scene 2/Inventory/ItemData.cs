using UnityEngine;
using UnityEngine.UI;

public class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string _name = "";
        string _description = "";
        int _amount = 0;
        int _value = 0;
        int _damage = 0;
        int _armour = 0;
        int _heal = 0;
        string _icon = "";
        string _mesh = "";
        ItemTypes _type;
        switch (itemID)
        {
            #region  Armour 0-99
            case 0:
                _name = "Fancy Boots";
                _description = "Boots that Fancy People Wear";
                _amount = 1;
                _value = 60;
                _armour = 2;
                _icon = "Armour/BootFancy";
                _mesh = "Armour/BootFancy";
                _type = ItemTypes.Armour;
                break;
            case 1:
                _name = "Iron Boots";
                _description = "Heavy Iron Boots";
                _amount = 1;
                _value = 45;
                _armour = 10;
                _icon = "Armour/BootIron";
                _mesh = "Armour/BootIron";
                _type = ItemTypes.Armour;
                break;
            case 2:
                _name = "Knights Boots";
                _description = "Strong Boots worn by the finest Knights";
                _amount = 1;
                _value = 80;
                _armour = 25;
                _icon = "Armour/BootKnight";
                _mesh = "Armour/BootKnight";
                _type = ItemTypes.Armour;
                break;
            case 3:
                _name = "Leather Boots";
                _description = "Soft Red Leather Boots";
                _amount = 1;
                _value = 10;
                _armour = 5;
                _icon = "Armour/BootLeather";
                _mesh = "Armour/BootLeather";
                _type = ItemTypes.Armour;
                break;
            case 10:
                _name = "Archers Bracers";
                _description = "Bracers word by archers to protect the forarms";
                _amount = 1;
                _value = 10;
                _armour = 5;
                _icon = "Armour/BracerArcher";
                _mesh = "Armour/BracerArcher";
                _type = ItemTypes.Armour;
                break;
            case 11:
                _name = "Barbarians Bracers";
                _description = "Bracers word by Barbarians to protect the forarms";
                _amount = 1;
                _value = 15;
                _armour = 7;
                _icon = "Armour/BracerBarbarian";
                _mesh = "Armour/BracerBarbarian";
                _type = ItemTypes.Armour;
                break;
            case 12:
                _name = "Bone Bracers";
                _description = "Bracers made out of Bone to protect the forarms";
                _amount = 1;
                _value = 15;
                _armour = 7;
                _icon = "Armour/BracerBone";
                _mesh = "Armour/BracerBone";
                _type = ItemTypes.Armour;
                break;
            case 13:
                _name = "Fancy Bracers";
                _description = "Bracers made out of Cloth worn by the Rich";
                _amount = 1;
                _value = 55;
                _armour = 1;
                _icon = "Armour/BracerFancy";
                _mesh = "Armour/BracerFancy";
                _type = ItemTypes.Armour;
                break;
            case 14:
                _name = "Guard Bracers";
                _description = "Bracers worn by Guards";
                _amount = 1;
                _value = 30;
                _armour = 5;
                _icon = "Armour/BracerGuard";
                _mesh = "Armour/BracerGuard";
                _type = ItemTypes.Armour;
                break;
            case 15:
                _name = "Hunters Bracers";
                _description = "Bracers made out of Leather worn by the Hunters";
                _amount = 1;
                _value = 25;
                _armour = 3;
                _icon = "Armour/BracerHunter";
                _mesh = "Armour/BracerHunter";
                _type = ItemTypes.Armour;
                break;
            case 16:
                _name = "Leather Bracers";
                _description = "Bracers made out of Leather";
                _amount = 1;
                _value = 35;
                _armour = 4;
                _icon = "Armour/BracerLeather";
                _mesh = "Armour/BracerLeather";
                _type = ItemTypes.Armour;
                break;
            case 17:
                _name = "Mage Bracers";
                _description = "Bracers made out of Cloth worn by the Mages";
                _amount = 1;
                _value = 60;
                _armour = 2;
                _icon = "Armour/BracerMage";
                _mesh = "Armour/BracerMage";
                _type = ItemTypes.Armour;
                break;
            case 18:
                _name = "Purple Bracers";
                _description = "Bracers made out of Purple Cloth";
                _amount = 1;
                _value = 20;
                _armour = 1;
                _icon = "Armour/BracerPurple";
                _mesh = "Armour/BracerPurple";
                _type = ItemTypes.Armour;
                break;
            case 19:
                _name = "Gold Bracers";
                _description = "Bracers made out of Gold worn by the Rich";
                _amount = 1;
                _value = 80;
                _armour = 4;
                _icon = "Armour/BracerRedGold";
                _mesh = "Armour/BracerRedGold";
                _type = ItemTypes.Armour;
                break;
            case 20:
                _name = "Bandit Chest Plate";
                _description = "Chest Plate worn by Bandits";
                _amount = 1;
                _value = 35;
                _armour = 3;
                _icon = "Armour/ChestPlateBandit";
                _mesh = "Armour/ChestPlateBandit";
                _type = ItemTypes.Armour;
                break;
            case 21:
                _name = "Bronze Chest Plate";
                _description = "Chest Plate made out of Bronze";
                _amount = 1;
                _value = 20;
                _armour = 2;
                _icon = "Armour/ChestPlateBronze";
                _mesh = "Armour/ChestPlateBronze";
                _type = ItemTypes.Armour;
                break;
            case 22:
                _name = "Iron Chest Plate";
                _description = "Chest Plate made out of Iron";
                _amount = 1;
                _value = 40;
                _armour = 4;
                _icon = "Armour/ChestPlateIron";
                _mesh = "Armour/ChestPlateIron";
                _type = ItemTypes.Armour;
                break;
            case 23:
                _name = "Knight Chest Plate";
                _description = "Chest Plate worn by Knights";
                _amount = 1;
                _value = 80;
                _armour = 6;
                _icon = "Armour/ChestPlateKnight";
                _mesh = "Armour/ChestPlateKnight";
                _type = ItemTypes.Armour;
                break;
            case 24:
                _name = "Steel Chest Plate";
                _description = "Chest Plate made out of Steel";
                _amount = 1;
                _value = 60;
                _armour = 5;
                _icon = "Armour/ChestPlateSteel";
                _mesh = "Armour/ChestPlateSteel";
                _type = ItemTypes.Armour;
                break;
            case 25:
                _name = "Studded Chest Plate";
                _description = "Leather Chest Plate with Studds";
                _amount = 1;
                _value = 45;
                _armour = 4;
                _icon = "Armour/ChestPlateStudded";
                _mesh = "Armour/ChestPlateStudded";
                _type = ItemTypes.Armour;
                break;
            case 30:
                _name = "Blue Cloak";
                _description = "Blue Cloth Cloak";
                _amount = 1;
                _value = 20;
                _armour = 1;
                _icon = "Armour/CloakBlue";
                _mesh = "Armour/CloakBlue";
                _type = ItemTypes.Armour;
                break;
            case 31:
                _name = "Pink Cloak";
                _description = "Pink Cloth Cloak";
                _amount = 1;
                _value = 20;
                _armour = 1;
                _icon = "Armour/CloakPink";
                _mesh = "Armour/CloakPink";
                _type = ItemTypes.Armour;
                break;
            case 32:
                _name = "Red Cloak";
                _description = "Red Cloth Cloak";
                _amount = 1;
                _value = 20;
                _armour = 1;
                _icon = "Armour/CloakRed";
                _mesh = "Armour/CloakRed";
                _type = ItemTypes.Armour;
                break;
            case 40:
                _name = "Fancy Gloves";
                _description = "Gloves that are fancy";
                _amount = 1;
                _value = 40;
                _armour = 1;
                _icon = "Armour/GloveFancy";
                _mesh = "Armour/GloveFancy";
                _type = ItemTypes.Armour;
                break;
            case 41:
                _name = "Iron Gloves";
                _description = "Gloves that are made of Iron";
                _amount = 1;
                _value = 55;
                _armour = 3;
                _icon = "Armour/GloveIron";
                _mesh = "Armour/GloveIron";
                _type = ItemTypes.Armour;
                break;
            case 42:
                _name = "Leather Gloves";
                _description = "Gloves that are made of Leather";
                _amount = 1;
                _value = 25;
                _armour = 2;
                _icon = "Armour/GloveLeather";
                _mesh = "Armour/GloveLeather";
                _type = ItemTypes.Armour;
                break;
            case 43:
                _name = "Steel Gloves";
                _description = "Gloves that are made of Steel";
                _amount = 1;
                _value = 80;
                _armour = 5;
                _icon = "Armour/GloveSteel";
                _mesh = "Armour/GloveSteel";
                _type = ItemTypes.Armour;
                break;
            case 50:
                _name = "Hood";
                _description = "A Cloth Hood";
                _amount = 1;
                _value = 10;
                _armour = 1;
                _icon = "Armour/HelmHood";
                _mesh = "Armour/HelmHood";
                _type = ItemTypes.Armour;
                break;
            case 51:
                _name = "Leather Helmet";
                _description = "Helmet made of Leather";
                _amount = 1;
                _value = 25;
                _armour = 2;
                _icon = "Armour/HelmLeather";
                _mesh = "Armour/HelmLeather";
                _type = ItemTypes.Armour;
                break;
            case 52:
                _name = "Spiked Helmet";
                _description = "Helmet made of Bone and Spikes";
                _amount = 1;
                _value = 30;
                _armour = 3;
                _icon = "Armour/HelmSpiked";
                _mesh = "Armour/HelmSpiked";
                _type = ItemTypes.Armour;
                break;
            case 53:
                _name = "Steel Helmet";
                _description = "Helmet made of Steel";
                _amount = 1;
                _value = 60;
                _armour = 5;
                _icon = "Armour/HelmSteel";
                _mesh = "Armour/HelmSteel";
                _type = ItemTypes.Armour;
                break;
            case 60:
                _name = "Bandit Pants";
                _description = "Pants worn by bandits";
                _amount = 1;
                _value = 20;
                _armour = 2;
                _icon = "Armour/PantsBandit";
                _mesh = "Armour/PantsBandit";
                _type = ItemTypes.Armour;
                break;
            case 61:
                _name = "Fancy Pants";
                _description = "Pants worn by the Rich";
                _amount = 1;
                _value = 80;
                _armour = 1;
                _icon = "Armour/PantsFancy";
                _mesh = "Armour/PantsFancy";
                _type = ItemTypes.Armour;
                break;
            case 62:
                _name = "Iron Pants";
                _description = "Pants made of Iron";
                _amount = 1;
                _value = 50;
                _armour = 3;
                _icon = "Armour/PantsIron";
                _mesh = "Armour/PantsIron";
                _type = ItemTypes.Armour;
                break;
            case 63:
                _name = "Leather Pants";
                _description = "Pants made of Leather";
                _amount = 1;
                _value = 30;
                _armour = 2;
                _icon = "Armour/PantsLeather";
                _mesh = "Armour/PantsLeather";
                _type = ItemTypes.Armour;
                break;
            case 70:
                _name = "Bone Pauldron";
                _description = "Pauldron made of Bone";
                _amount = 1;
                _value = 20;
                _armour = 2;
                _icon = "Armour/PauldronBone";
                _mesh = "Armour/PauldronBone";
                _type = ItemTypes.Armour;
                break;
            case 71:
                _name = "Fancy Pauldron";
                _description = "Pauldron worn by the Rich";
                _amount = 1;
                _value = 80;
                _armour = 3;
                _icon = "Armour/PauldronFancy";
                _mesh = "Armour/PauldronFancy";
                _type = ItemTypes.Armour;
                break;
            case 72:
                _name = "Leather Pauldron";
                _description = "Pauldron made of Leather";
                _amount = 1;
                _value = 30;
                _armour = 4;
                _icon = "Armour/PauldronLeather";
                _mesh = "Armour/PauldronLeather";
                _type = ItemTypes.Armour;
                break;
            case 73:
                _name = "Red Leather Pauldron";
                _description = "Pauldron made of Red Leather";
                _amount = 1;
                _value = 50;
                _armour = 6;
                _icon = "Armour/PauldronRed";
                _mesh = "Armour/PauldronRed";
                _type = ItemTypes.Armour;
                break;
            case 80:
                _name = "Robe";
                _description = "Robe worn by mages";
                _amount = 1;
                _value = 60;
                _armour = 2;
                _icon = "Armour/Robe";
                _mesh = "Armour/Robe";
                _type = ItemTypes.Armour;
                break;
            #endregion
            #region  Trinket 100-199
            case 100:
                _name = "Cloth Belt";
                _description = "Simple Cloth Belt";
                _amount = 1;
                _value = 5;
                _icon = "Trinket/BeltCloth";
                _mesh = "Trinket/BeltCloth";
                _type = ItemTypes.Trinket;
                break;
            case 101:
                _name = "Fancy Belt";
                _description = "Fancy Cloth Belt";
                _amount = 1;
                _value = 50;
                _icon = "Trinket/BeltFancy";
                _mesh = "Trinket/BeltFancy";
                _type = ItemTypes.Trinket;
                break;
            case 102:
                _name = "Hunters Belt";
                _description = "Simple Fur Belt";
                _amount = 1;
                _value = 10;
                _icon = "Trinket/BeltHunter";
                _mesh = "Trinket/BeltHunter";
                _type = ItemTypes.Trinket;
                break;
            case 103:
                _name = "Iron Belt";
                _description = "Sturdy Iron Belt";
                _amount = 1;
                _value = 25;
                _icon = "Trinket/BeltIron";
                _mesh = "Trinket/BeltIron";
                _type = ItemTypes.Trinket;
                break;
            case 104:
                _name = "Leather Belt";
                _description = "Simple Leather Belt";
                _amount = 1;
                _value = 15;
                _icon = "Trinket/BeltLeather";
                _mesh = "Trinket/BeltLeather";
                _type = ItemTypes.Trinket;
                break;
            case 105:
                _name = "Rope Belt";
                _description = "Simple Rope Belt";
                _amount = 1;
                _value = 1;
                _icon = "Trinket/BeltRope";
                _mesh = "Trinket/BeltRope";
                _type = ItemTypes.Trinket;
                break;
            case 106:
                _name = "Royal Belt";
                _description = "Royal Cloth Belt";
                _amount = 1;
                _value = 80;
                _icon = "Trinket/BeltRoyal";
                _mesh = "Trinket/BeltRoyal";
                _type = ItemTypes.Trinket;
                break;
            case 110:
                _name = "Blue Necklace";
                _description = "Blue and Silver Necklace";
                _amount = 1;
                _value = 80;
                _icon = "Trinket/NecklaceBlue";
                _mesh = "Trinket/NecklaceBlue";
                _type = ItemTypes.Trinket;
                break;
            case 111:
                _name = "Gold Necklace";
                _description = "Gold Chain Necklace";
                _amount = 1;
                _value = 150;
                _icon = "Trinket/NecklaceGold";
                _mesh = "Trinket/NecklaceGold";
                _type = ItemTypes.Trinket;
                break;
            case 112:
                _name = "Purple Necklace";
                _description = "Purple and Silver Necklace";
                _amount = 1;
                _value = 90;
                _icon = "Trinket/NecklacePurple";
                _mesh = "Trinket/NecklacePurple";
                _type = ItemTypes.Trinket;
                break;
            case 113:
                _name = "Red Necklace";
                _description = "Red and Silver Necklace";
                _amount = 1;
                _value = 100;
                _icon = "Trinket/NecklaceRed";
                _mesh = "Trinket/NecklaceRed";
                _type = ItemTypes.Trinket;
                break;
            case 120:
                _name = "Red Ring";
                _description = "Red and Silver Ring";
                _amount = 1;
                _value = 100;
                _icon = "Trinket/RingRed";
                _mesh = "Trinket/RingRed";
                _type = ItemTypes.Trinket;
                break;
            case 121:
                _name = "Gold Ring";
                _description = "Gold Band Ring";
                _amount = 1;
                _value = 200;
                _icon = "Trinket/RingGold";
                _mesh = "Trinket/RingGold";
                _type = ItemTypes.Trinket;
                break;
            case 122:
                _name = "Purple Ring";
                _description = "Purple and Gold Ring";
                _amount = 1;
                _value = 250;
                _icon = "Trinket/RingPurple";
                _mesh = "Trinket/RingPurple";
                _type = ItemTypes.Trinket;
                break;
            case 123:
                _name = "Royal Ring";
                _description = "Ring worn by Royalty";
                _amount = 1;
                _value = 1000;
                _icon = "Trinket/RingRoyal";
                _mesh = "Trinket/RingRoyal";
                _type = ItemTypes.Trinket;
                break;
            #endregion
            #region  Weapon 200-299
            case 200:
                _name = "Battle Axe";
                _description = "Axe Designed for Battle";
                _amount = 1;
                _value = 80;
                _damage = 100;
                _icon = "Weapon/AxeBattle";
                _mesh = "Weapon/AxeBattle";
                _type = ItemTypes.Weapon;
                break;
            case 201:
                _name = "Iron Axe";
                _description = "Axe made of Iron";
                _amount = 1;
                _value = 25;
                _damage = 10;
                _icon = "Weapon/AxeIron";
                _mesh = "Weapon/AxeIron";
                _type = ItemTypes.Weapon;
                break;
            case 202:
                _name = "Axe of Blight Shore";
                _description = "Magic Axe powerful enough to slay all enemies";
                _amount = 1;
                _value = 1500;
                _damage = 400;
                _icon = "Weapon/AxeMagic";
                _mesh = "Weapon/AxeMagic";
                _type = ItemTypes.Weapon;
                break;
            case 203:
                _name = "Steel Axe";
                _description = "Axe made of Steel";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/AxeSteel";
                _mesh = "Weapon/AxeSteel";
                _type = ItemTypes.Weapon;
                break;
            case 210:
                _name = "Curved Bow";
                _description = "Bow with a Curved frame";
                _amount = 1;
                _value = 80;
                _damage = 75;
                _icon = "Weapon/BowCurved";
                _mesh = "Weapon/BowCurved";
                _type = ItemTypes.Weapon;
                break;
            case 211:
                _name = "Fancy Bow";
                _description = "Bow with Fancy finishings";
                _amount = 1;
                _value = 60;
                _damage = 40;
                _icon = "Weapon/BowFancy";
                _mesh = "Weapon/BowFancy";
                _type = ItemTypes.Weapon;
                break;
            case 212:
                _name = "Simple Bow";
                _description = "Wooden Bow";
                _amount = 1;
                _value = 15;
                _damage = 7;
                _icon = "Weapon/BowSimple";
                _mesh = "Weapon/BowSimple";
                _type = ItemTypes.Weapon;
                break;
            case 220:
                _name = "Emerald Staff";
                _description = "Staff made with a bright Emerald";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/StaffEmerald";
                _mesh = "Weapon/StaffEmerald";
                _type = ItemTypes.Weapon;
                break;
            case 221:
                _name = "Ruby Staff";
                _description = "Staff made with a bright Ruby";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/StaffRuby";
                _mesh = "Weapon/StaffRuby";
                _type = ItemTypes.Weapon;
                break;
            case 222:
                _name = "Saphire Staff";
                _description = "Staff made with a bright Saphire";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/StaffSaphire";
                _mesh = "Weapon/StaffSaphire";
                _type = ItemTypes.Weapon;
                break;
            case 223:
                _name = "Wood Staff";
                _description = "Staff mand of Wood";
                _amount = 1;
                _value = 10;
                _damage = 5;
                _icon = "Weapon/StaffWood";
                _mesh = "Weapon/StaffWood";
                _type = ItemTypes.Weapon;
                break;
            case 230:
                _name = "SwordFancy";
                _description = "SwordFancy";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/SwordFancy";
                _mesh = "Weapon/SwordFancy";
                _type = ItemTypes.Weapon;
                break;
            case 231:
                _name = "Iron Sword";
                _description = "Sword made of Iron";
                _amount = 1;
                _value = 35;
                _damage = 45;
                _icon = "Weapon/SwordIron";
                _mesh = "Weapon/SwordIron";
                _type = ItemTypes.Weapon;
                break;
            case 232:
                _name = "Simple Sword";
                _description = "Sword...use the pointy end";
                _amount = 1;
                _value = 50;
                _damage = 25;
                _icon = "Weapon/SwordSimple";
                _mesh = "Weapon/SwordSimple";
                _type = ItemTypes.Weapon;
                break;
            case 233:
                _name = "Steel Sword";
                _description = "Sword made of Steel";
                _amount = 1;
                _value = 60;
                _damage = 75;
                _icon = "Weapon/SwordSteel";
                _mesh = "Weapon/SwordSteel";
                _type = ItemTypes.Weapon;
                break;
            #endregion
            #region  Potion 300-399
            case 300:
                _name = "Major Potion Empty";
                _description = "Empty Major Potion Bottle";
                _amount = 1;
                _value = 50;
                _heal = 0;
                _icon = "Potion/MajorPotionEmpty";
                _mesh = "Potion/MajorPotionEmpty";
                _type = ItemTypes.Potion;
                break;
            case 301:
                _name = "Major Health Potion";
                _description = "Bottle of Major Health Potion";
                _amount = 1;
                _value = 500;
                _heal = 100;
                _icon = "Potion/MajorPotionHealth";
                _mesh = "Potion/MajorPotionHealth";
                _type = ItemTypes.Potion;
                break;
            case 302:
                _name = "Major Mana Potion";
                _description = "Bottle of Major Mana Potion";
                _amount = 1;
                _value = 500;
                _heal = 100;
                _icon = "Potion/MajorPotionMana";
                _mesh = "Potion/MajorPotionMana";
                _type = ItemTypes.Potion;
                break;
            case 303:
                _name = "Major Stamina Potion";
                _description = "Bottle of Major Stamina Potion";
                _amount = 1;
                _value = 500;
                _heal = 100;
                _icon = "Potion/MajorPotionStamina";
                _mesh = "Potion/MajorPotionStamina";
                _type = ItemTypes.Potion;
                break;
            case 304:
                _name = "Minor Potion Empty";
                _description = "Empty Minor Potion Bottle";
                _amount = 1;
                _value = 25;
                _heal = 0;
                _icon = "Potion/MinorPotionEmpty";
                _mesh = "Potion/MinorPotionEmpty";
                _type = ItemTypes.Potion;
                break;
            case 305:
                _name = "Minor Health Potion";
                _description = "Minor Health Potion Bottle";
                _amount = 1;
                _value = 250;
                _heal = 50;
                _icon = "Potion/MinorPotionHealth";
                _mesh = "Potion/MinorPotionHealth";
                _type = ItemTypes.Potion;
                break;
            case 306:
                _name = "Minor Mana Potion";
                _description = "Minor Mana Potion Bottle";
                _amount = 1;
                _value = 250;
                _heal = 50;
                _icon = "Potion/MinorPotionMana";
                _mesh = "Potion/MinorPotionMana";
                _type = ItemTypes.Potion;
                break;
            case 307:
                _name = "Minor Stamina Potion";
                _description = "Minor Stamina Potion Bottle";
                _amount = 1;
                _value = 250;
                _heal = 50;
                _icon = "Potion/MinorPotionGreen";
                _mesh = "Potion/MinorPotionGreen";
                _type = ItemTypes.Potion;
                break;

            #endregion
            #region  Scroll 400-499
            case 400:
                _name = "Blue Book";
                _description = "A book that is Blue";
                _amount = 1;
                _value = 25;
                _icon = "Scroll/BookBlue";
                _mesh = "Scroll/BookBlue";
                _type = ItemTypes.Scroll;
                break;
            case 401:
                _name = "Green Book";
                _description = "A book that is Green";
                _amount = 1;
                _value = 25;
                _icon = "Scroll/BookGreen";
                _mesh = "Scroll/BookGreen";
                _type = ItemTypes.Scroll;
                break;
            case 402:
                _name = "Purple Book";
                _description = "A book that is Purple";
                _amount = 1;
                _value = 25;
                _icon = "Scroll/BookPurple";
                _mesh = "Scroll/BookPurple";
                _type = ItemTypes.Scroll;
                break;
            case 403:
                _name = "Red Book";
                _description = "A book that is Red";
                _amount = 1;
                _value = 25;
                _icon = "Scroll/BookRed";
                _mesh = "Scroll/BookRed";
                _type = ItemTypes.Scroll;
                break;
            case 404:
                _name = "Scroll";
                _description = "An old Scroll";
                _amount = 1;
                _value = 25;
                _icon = "Scroll/Scroll";
                _mesh = "Scroll/Scroll";
                _type = ItemTypes.Scroll;
                break;
            #endregion
            #region  Food 500-599
            case 500:
                _name = "Apple";
                _description = "Munchies and Crunchies";
                _amount = 1;
                _value = 5;
                _heal = 1;
                _icon = "Food/Apple";
                _mesh = "Food/Apple";
                _type = ItemTypes.Food;
                break;
            case 501:
                _name = "Meat";
                _description = "Roasted Meat";
                _amount = 1;
                _value = 10;
                _heal = 5;
                _icon = "Food/Meat";
                _mesh = "Food/Meat";
                _type = ItemTypes.Food;
                break;
            #endregion
            #region  Ingredient 600-699
            case 600:
                _name = "Carrot";
                _description = "Short Orange Stick";
                _amount = 1;
                _value = 1;
                _heal = 1;
                _icon = "Ingredient/Carrot";
                _mesh = "Ingredient/Carrot";
                _type = ItemTypes.Ingredient;
                break;
            case 601:
                _name = "Cheese";
                _description = "Smelly and Yellow";
                _amount = 1;
                _value = 5;
                _heal = 2;
                _icon = "Ingredient/Cheese";
                _mesh = "Ingredient/Cheese";
                _type = ItemTypes.Ingredient;
                break;
            case 602:
                _name = "Egg";
                _description = "Future Chicken";
                _amount = 1;
                _value = 1;
                _heal = 1;
                _icon = "Ingredient/Egg";
                _mesh = "Ingredient/Egg";
                _type = ItemTypes.Ingredient;
                break;
            case 603:
                _name = "Mint";
                _description = "Good for Tea";
                _amount = 1;
                _value = 1;
                _heal = 1;
                _icon = "Ingredient/Herb1";
                _mesh = "Ingredient/Herb1";
                _type = ItemTypes.Ingredient;
                break;
            case 604:
                _name = "Basil";
                _description = "Flavour good in cooking";
                _amount = 1;
                _value = 1;
                _heal = 1;
                _icon = "Ingredient/Herb2";
                _mesh = "Ingredient/Herb2";
                _type = ItemTypes.Ingredient;
                break;
            case 605:
                _name = "Yellow Spice";
                _description = "Do you wanna stay warm?";
                _amount = 1;
                _value = 1;
                _heal = 1;
                _icon = "Ingredient/Herb3";
                _mesh = "Ingredient/Herb3";
                _type = ItemTypes.Ingredient;
                break;
            #endregion
            #region  Material 700-799
            case 700:
                _name = "Gem";
                _description = "Create Magical items";
                _amount = 1;
                _value = 300;
                _icon = "Material/Gem";
                _mesh = "Material/Gem";
                _type = ItemTypes.Material;
                break;
            case 701:
                _name = "Iron Ingot";
                _description = "Create Iron Items";
                _amount = 1;
                _value = 10;
                _icon = "Material/Ingot";
                _mesh = "Material/Ingot";
                _type = ItemTypes.Material;
                break;
            #endregion
            #region  Misc 800-899
            case 800:
                _name = "Money";
                _description = "Use to Buy things";
                _amount = 1;
                _value = 1;
                _icon = "Misc/Money";
                _mesh = "Misc/Money";
                _type = ItemTypes.Money;
                break;
            #endregion        
            default:
                itemID = 500;
                _name = "Apple";
                _description = "Munchies and Crunchies";
                _amount = 1;
                _value = 5;
                _heal = 1;
                _icon = "Food/Apple";
                _mesh = "Food/Apple";
                _type = ItemTypes.Food;
                break;
        }
        Item temp = new Item
        {
            ID = itemID,
            Name = _name,
            Description = _description,
            Amount = _amount,
            Value = _value,
            Damage = _damage,
            Armour = _armour,
            Heal = _heal,
            Icon = Resources.Load("Icons/" + _icon) as Sprite,
            Mesh = Resources.Load("Mesh/" + _mesh) as GameObject,
            ItemTypes = _type
        };
        return temp;
    }
}
