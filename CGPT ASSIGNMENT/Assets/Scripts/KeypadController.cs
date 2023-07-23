using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public GameObject keypadCanvas; // Reference to the Keypad Canvas in the Inspector
    private bool CursorVisibility;
    public CharacterController player;
    private PlayerLook playerLook;
    private bool keypadActive = false;
    public Button exitButton;

    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        playerLook = FindObjectOfType<PlayerLook>();
        keypadCanvas.SetActive(false);
        CursorVisibility = Cursor.visible;
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnMouseDown()
    {
        keypadActive = !keypadActive;
        keypadCanvas.SetActive(keypadActive);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player.enabled = false;
        playerLook.enabled = false;

    }

    public void OnExitButtonClick()
    {
        keypadActive = false;
        keypadCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = CursorVisibility;

        player.enabled = true;
        playerLook.enabled = true;
    }
}
