using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
public static class SaveSystem 
{
    const string PLAYER_SUB = "/SaveFile_" ;
    public static List<Player> savedGames = new List<Player>();
    public static void SaveGameState(Player player, string slotNum)
    {
        //SaveSystem.savedGames.Add(Player.current);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLAYER_SUB + slotNum + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static PlayerData LoadGameState(string slotNum)
    {
        string path = Application.persistentDataPath + PLAYER_SUB + slotNum + ".dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }
}
