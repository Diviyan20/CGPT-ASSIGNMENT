using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasOnP : MonoBehaviour
{
    public GameObject pausecanvas; // Reference to the UI Canvas GameObject

    void Start()
    {
        pausecanvas.SetActive(false); // Set the canvas to be initially hidden
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the canvas visibility when the 'P' key is pressed
            bool canvasActive = !pausecanvas.activeSelf;
            pausecanvas.SetActive(canvasActive);

            // Enable or disable the mouse cursor based on the canvas visibility
            if (canvasActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f; // Pause the game by setting timeScale to 0
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f; // Resume the game by setting timeScale back to 1
            }
        }
    }
}


