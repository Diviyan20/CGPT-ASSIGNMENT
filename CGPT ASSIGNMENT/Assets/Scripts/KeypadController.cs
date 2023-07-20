using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public GameObject keypadCanvas; // Reference to the Keypad Canvas in the Inspector
    private bool keypadActive = false;

    private void Start()
    {
        // Set the Keypad Canvas to inactive at the start of the game
        keypadCanvas.SetActive(false);
    }

    private void Update()
    {
        // Detect player input for "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle keypad visibility on "E" press
            keypadActive = true;
            keypadCanvas.SetActive(keypadActive);
        }
    }
}
