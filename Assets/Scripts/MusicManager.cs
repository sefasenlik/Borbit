using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton instance

    private void Awake()
    {
        // If an instance already exists, destroy the new one to avoid duplicate music
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance and make sure it's not destroyed on scene load
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}