using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerData playerData;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializeGame() 
    {
        Application.targetFrameRate = 60; // add this as first line
        playerData = SaveSystem.LoadOrCreate();
        ProcessOfflineProgress();
        playerData.lastLoginTime = DateTime.UtcNow.ToString("O");
        SaveSystem.Save(playerData);
    }
    private void ProcessOfflineProgress()
    {
        if (!DateTime.TryParse(playerData.lastLoginTime, out DateTime lastLogin))
        {
            Debug.LogWarning("GameManager: could not parse lastLoginTime, skipping offline progress");
            return;
        }
        TimeSpan timeAway = DateTime.UtcNow - lastLogin;

        // If negative or less than 1 second — first launch or clock weirdness
        // Skip offline progress entirely, nothing to give
        if (timeAway.TotalSeconds < 1)
        {
            Debug.Log("GameManager: first launch or invalid time gap, skipping offline progress");
            return;
        }

        double secondsAway = Math.Min(timeAway.TotalSeconds, 8 * 3600);
        Debug.Log($"GameManager: player was away for {secondsAway} seconds");

        // We'll fill in resource calculation here in Week 2
        // when we have the resource generation rates designed
        // For now we just log the time — the structure is ready
        // ProcessOfflineResources(secondsAway);
        // ProcessBarracksProduction(secondsAway);
    }
    public void SaveNow()
    {
        SaveSystem.Save(playerData);
    }
}
