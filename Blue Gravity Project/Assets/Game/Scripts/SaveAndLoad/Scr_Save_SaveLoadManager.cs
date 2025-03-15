using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Scr_Save_SaveLoadManager : MonoBehaviour
{
    private static string SavePath => Application.persistentDataPath + "/savedata.json";

    public static void SaveGame( int playerMoney, float playerHealth)
    {
        Scr_Save_GameData data = new Scr_Save_GameData();

        /*foreach (var item in items)
        {
            data.ItemIDs.Add(item.ItemName);
            
            data.ItemPositions.Add(items.IndexOf(item));
        }*/

        data.PlayerMoney = playerMoney;
        data.PlayerHealth = playerHealth;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        
        Debug.Log("Game saved successfully.");
    }

    public static Scr_Save_GameData LoadGame()
    {
        string path = SavePath;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Scr_Save_GameData data = JsonUtility.FromJson<Scr_Save_GameData>(json);

            Debug.Log("Game loaded successfully.");
            return data;
        }
        else
        {
            Debug.Log("No saved game found.");
            return new Scr_Save_GameData();
        }
    }
}
