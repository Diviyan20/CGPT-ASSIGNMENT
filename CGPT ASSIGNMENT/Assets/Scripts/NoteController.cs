using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    public GameObject noteContent; // Reference to the GameObject containing the note's content (Text or Image)
    public CharacterController player; // Reference to the player's CharacterController

    private bool RevealNote = false;
    private bool CursorVisibility;
    private PlayerLook playerLook;

    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        CursorVisibility = Cursor.visible;
        playerLook = FindObjectOfType<PlayerLook>();
    }

    private void OnMouseDown()
    {
        if (!RevealNote)
        {
            // Reveal the note content here (e.g., show a text or image)
            noteContent.SetActive(true);
            RevealNote = true;

            // Lock player movement
            player.enabled = false;
            playerLook.enabled = false;

            // Enable free mouse cursor movement
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Add an exit button method here to be called by the button
    public void ExitNote()
    {
        // Hide the note content
        noteContent.SetActive(false);
        RevealNote = false;

        // Unlock player movement and ability to look around
        player.enabled = true;
        playerLook.enabled = true;

        // Restore the original cursor settings
        Cursor.visible = CursorVisibility;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
}


