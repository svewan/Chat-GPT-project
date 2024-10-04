using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the level selection menu UI
    public GameObject levelSelectorUI;

    // Start the game from Level 1
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Replace "Level1" with the actual name of your first level scene
    }

    // Open the level selection menu
    public void OpenLevelSelector()
    {
        levelSelectorUI.SetActive(true); // Show the level selector UI
    }

    // Close the level selection menu
    public void CloseLevelSelector()
    {
        levelSelectorUI.SetActive(false); // Hide the level selector UI
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit(); // Quits the application
        Debug.Log("Game is quitting..."); // Log message for editor, won't appear in the final build
    }

    // Load a specific level from the level selector
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // Load the selected level by name
    }
}
