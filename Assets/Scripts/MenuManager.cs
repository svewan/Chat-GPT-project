using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    // Method to restart the game by reloading the current scene
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    // Method to quit the game and go to the main menu
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game time is resumed
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene (replace "MainMenu" with your scene name if needed)
    }

    // Method to exit the application (for use when the game is built)
    public void QuitGame()
    {
        Application.Quit(); // Quits the application
    }
}
