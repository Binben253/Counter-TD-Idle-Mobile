using UnityEngine;
using System.IO;
using System;

public static class SaveSystem
{
    private static string SavePath =>
        Path.Combine(Application.persistentDataPath, "playerdata.json");
    private static string TempPath =>
        Path.Combine(Application.persistentDataPath, "playerdata.tmp");
    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(TempPath, json);
        File.Copy(TempPath, SavePath, overwrite: true);
        File.Delete(TempPath);
    }
    public static PlayerData Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("Save file not found, returning new PlayerData.");
            return CreateNewPlayerData();
        }
        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PlayerData>(json);
    }
    public static PlayerData CreateNewPlayerData()
    {
        return new PlayerData
        {
            playerID = System.Guid.NewGuid().ToString(),
            lastLoginTime = DateTime.UtcNow.ToString("O"),
            meat = 100,
            wood = 50,
            ore = 50,
            coins = 0
        };
    }
    public static PlayerData LoadOrCreate()
    {
        if (File.Exists(SavePath)) 
        {
            string json = File.ReadAllText(SavePath);

            // TryParse pattern — attempt to deserialize, 
            // fall back to new data if something is wrong
            // This protects against corrupted save files
            try
            {
                PlayerData data = JsonUtility.FromJson<PlayerData>(json);
                if (data != null) return data;
            }
            catch (Exception e) 
            {
                Debug.LogError("SaveSystem: saave file corrupted - " + e.Message);
            }
        }

        // No file or corrupted file — create fresh
        return CreateNewPlayerData();
    }
}
