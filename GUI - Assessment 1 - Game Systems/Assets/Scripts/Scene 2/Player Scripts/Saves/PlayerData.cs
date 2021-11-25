[System.Serializable]
/*
 Serialization is the autimatic process of transforming data structures or objects into a formate tha unity can 
store and reconstruct later.
Serialization is the process of converting an object into a stream of bytes to store the obeject or transmit it to memory, database or file
its main purpoise is to savce the sate of an objecxt in order to be able to recreate it when needed,
the reverse of the serialization is called>>> Deserialization
the Serialixation System is written in c++*/
/*
 Playerdata or your main data scrip is the bride between your binary save and game, it stores all the infor on the data you want to save
 */
public class PlayerData 
{
    //Data from the game we want to save
    public string playerName;
    public int level;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ, rX, rY, rZ, rW;
    public PlayerData (PlayerHandler player)
    {
        playerName = player.name;
        level = 0;
        maxHealth = player.attributes[0].maxValue;
        maxMana = player.attributes[1].maxValue;
        maxStamina = player.attributes[2].maxValue;

        curHealth = player.attributes[0].currentValue;
        curMana = player.attributes[1].currentValue;
        curStamina = player.attributes[2].currentValue;
        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }

}
