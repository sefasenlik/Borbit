using UnityEngine;
using UnityEngine.SceneManagement; // For loading/reloading scenes
using UnityEngine.UI; // For UI elements
using TMPro;

public class RocketCollision : MonoBehaviour
{
    public TextMeshProUGUI crashMessageText;  // Reference to the TextMeshPro object
    public GameObject gameOverPanel; // Reference to the GameOverPanel
    public string crashableTag = "Crashable"; // Tag for crashable objects
    public string blackHoleTag = "BlackHole"; // Tag for crashable objects


    void Start()
    {
        // Make sure the gameOverPanel is hidden at the start
        gameOverPanel.SetActive(false);
        Time.timeScale = 1; // Resume time
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we collided with a solid object
        if (collision.gameObject.CompareTag(crashableTag))
        {
            UponCollision();
        }
        if (collision.gameObject.CompareTag(blackHoleTag))
        {
            // Change the TextMeshPro text when a collision occurs
            crashMessageText.text = "Level complete!";
            UponCollision();
        }
    }

    public void UponCollision()
    {
        // Display the Game Over dialog
        gameOverPanel.SetActive(true);
        // Optionally, stop time to pause the game
        Time.timeScale = 0;
    }

    // Function to Retry the level
    public void Retry()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to Exit the game
    public void Exit()
    {
        Time.timeScale = 1; // Resume time
        // If you're running in the editor, use this to stop the play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // For standalone builds
        #endif
    }
}
