using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Text DisplayNumbers; // Referring to the number display Text UI element
    private string enteredNumbers = ""; // Storing the entered numbers as a string
    private int passwordLength = 4; // Setting the max password Length to 4 numbers
    private string password = "1234";
    
    // Method to handle button presses and update the number display
    public void OnButtonPress(string buttonValue)
    {
        if (enteredNumbers.Length < passwordLength)
        {
            enteredNumbers += buttonValue;
            UpdateNumberDisplay();
        }
    }

    // Method to update the number display text
    private void UpdateNumberDisplay()
    {
        DisplayNumbers.text = enteredNumbers;
    }

    public void OnClearButtonPress()
    {
        enteredNumbers = "";
        UpdateNumberDisplay();
    }

    public void OnEnterButtonPress()
    {
        if (enteredNumbers == password)
        {
            DisplayNumbers.text = "CORRECT!";
        }

        else
        {
            DisplayNumbers.text = "INCORRECT!";
        }
    }
}
