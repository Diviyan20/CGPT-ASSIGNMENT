using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Text numberDisplay; // Reference to the number display Text UI element in the Inspector
    private string enteredNumbers = ""; // Variable to store the entered numbers as a string
    private int maxPasscodeLength = 4; // Set the maximum length of the passcode here

    // Method to handle button presses and update the number display
    public void OnButtonPress(string buttonValue)
    {
        if (enteredNumbers.Length < maxPasscodeLength)
        {
            enteredNumbers += buttonValue;
            UpdateNumberDisplay();
        }
    }

    // Method to update the number display text
    private void UpdateNumberDisplay()
    {
        numberDisplay.text = enteredNumbers;
    }

    // Method to handle when the "Clear" button is pressed
    public void OnClearButtonPress()
    {
        enteredNumbers = "";
        UpdateNumberDisplay();
    }

    // Method to handle when the "Enter" button is pressed (You can use this to check the entered passcode)
    public void OnEnterButtonPress()
    {
        // Implement your logic to check the entered passcode here
        Debug.Log("Entered passcode: " + enteredNumbers);
    }
}
