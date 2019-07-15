using System.IO;
//using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    static string location = Application.persistentDataPath + "/player";
    static string extension = ".data";

    public static void Save(Player player, int slotNumber)
    {
        // TO DO: Save key in a file
        // TO DO: Get key from file on save

        CharacterSaveData data = new CharacterSaveData(player);
        FileStream stream = new FileStream(location + slotNumber.ToString() + extension, FileMode.Create, FileAccess.Write);
        //AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        //CryptoStream crypto = new CryptoStream(stream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        BinaryFormatter format = new BinaryFormatter();

        format.Serialize(stream, data);

        //crypto.Close();
        stream.Close();
    }

    public static CharacterSaveData Load(int slotNumber)
    {
        // TO DO: Get key from file on load

        FileStream stream = new FileStream(location + slotNumber.ToString() + extension, FileMode.Open, FileAccess.Read);
        //AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        //CryptoStream crypto = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Read);
        BinaryFormatter format = new BinaryFormatter();

        CharacterSaveData data = format.Deserialize(stream) as CharacterSaveData;

        //crypto.Close();
        stream.Close();

        return data;
    }
}
