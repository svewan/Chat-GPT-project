using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class GoalTrigger : MonoBehaviour
{
    public GameObject goalMenu; // Reference to the goal menu
    public TextMeshProUGUI timerText;      // Reference to the TMP UI element displaying the timer
    public TextMeshProUGUI finalTimeText;  // Reference to the TMP UI element displaying the final time

    private float timer = 0f;   // Tracks the elapsed time
    private bool gameEnded = false; // Tracks whether the game is finished

    void Start()
    {
        // Ensure the goal menu is initially hidden and the timer is shown
        if (goalMenu != null)
        {
            goalMenu.SetActive(false);
        }
        if (timerText != null)
        {
            timerText.text = "Time: 0.00"; // Initialize timer text
        }
    }

    void Update()
    {
        // Increment the timer if the game hasn't ended yet
        if (!gameEnded)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // Detect when the player touches the goal
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            // Stop the timer and show the goal menu when the player reaches the goal
            gameEnded = true;

            // Show the final time on the goal menu
            if (finalTimeText != null)
            {
                finalTimeText.text = "Final Time: " + timer.ToString("F2");
            }

            // Make the timer invisible by disabling the timerText object
            if (timerText != null)
            {
                timerText.gameObject.SetActive(false); // Disable the timer text object
            }

            // Show the goal menu
            if (goalMenu != null)
            {
                goalMenu.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
        }
    }

    // Update the timer text display
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2"); // Display time with two decimal places
        }
    }
}
