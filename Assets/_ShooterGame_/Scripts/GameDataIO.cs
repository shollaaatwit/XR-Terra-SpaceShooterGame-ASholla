using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameDataIO
{
    private const string FILENAME = "gameData.json";


    public static void SaveGameData(GameData data)
    {
        string path = Application.persistentDataPath + "/" + FILENAME;
        Debug.Log("Saving data to" + path);

        string json = JsonUtility.ToJson(data);
        Debug.Log("Json data: " + json);

        File.WriteAllText(path, json);
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/" + FILENAME;
        Debug.Log("Loading data from " + path);

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);

        }
        else
        {
            
        }
        return null;
    }

}
