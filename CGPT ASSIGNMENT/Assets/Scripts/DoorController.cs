using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float slidingDistance = 2.0f; // The distance the door will slide open
    public float slidingSpeed = 3.0f; // The speed at which the door slides open
    public bool isLocked = false; // Indicates if the door is locked initially
    private bool isOpen = false;

    private void Update()
    {
        // Toggle door state on "E" press if it's not locked
        if (!isLocked && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            Destroy(gameObject);
        }
    }

    // Method to open the door when the correct passcode is entered
    public void OpenDoor()
    {
        isLocked = false;
    }
}
