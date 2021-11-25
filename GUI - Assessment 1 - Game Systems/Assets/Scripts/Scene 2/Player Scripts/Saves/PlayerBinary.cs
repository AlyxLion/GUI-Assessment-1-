using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerBinary 
{
    public static void SaveData(PlayerHandler player)
    {
        //reference our binary formaatter
        BinaryFormatter formatter = new BinaryFormatter();
        // location to save
        string path = "C:/Users/LionA/Desktop/Unity Projects/GUI Game Design Group A/"+"Kitten.png";
        //create file at file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //what data to write to the file
        PlayerData data = new PlayerData(player);
        //write it and convert to bytes
        formatter.Serialize(stream, data);
        //and we are done
        stream.Close();

    }
    public static PlayerData LoadData(PlayerHandler player)
    {
        //location to load
        string path = "C:/Users/LionA/Desktop/Unity Projects/GUI Game Design Group A/" + "Kitten.png";
        //of we have a dile at that path
        if (File.Exists(path))
        {
            //get our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read the data from the path 
            FileStream stream = new FileStream(path, FileMode.Open);
            //set the data from what it is back into its usable c# form
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //we are done with the acction
            stream.Close();
            //send usable data back to the PlayerData script
            return data;
        }
        return null;
    }
}
