using UnityEditor.Build.Content;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    [SerializeField] private float saveInterval = 30f; // Save every 30 seconds
    private float timer =0f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= saveInterval)
        {
            PerformSave();
            timer = 0f; // Reset the timer after saving
        }
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            PerformSave();
        }
    }

    private void OnApplicationQuit()
    {
        PerformSave();
    }

    public void PerformSave()
    {
        if (gameManager != null & gameManager.playerData != null)
        {
            SaveSystem.Save(gameManager.playerData);
            Debug.Log($"AutoSave: saved at {System.DateTime.UtcNow}");
        }
        else
        {
            Debug.LogWarning("GameManager not found. Auto-save failed.");
        }
    }
}
