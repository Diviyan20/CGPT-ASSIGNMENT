using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float slidingDistance = 2.0f; // The distance the door will slide open
    public float slidingSpeed = 3.0f; // The speed at which the door slides open
    public bool isLocked = true; // Indicates if the door is locked initially

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + (transform.right * slidingDistance);
    }

    private void Update()
    {
        // Detect player input for "E" key
        if (isLocked && Input.GetKeyDown(KeyCode.E))
        {
            // Show a message or feedback to indicate the door is locked
            Debug.Log("The door is locked. Find the passcode to unlock it.");
        }
        else if (!isLocked && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle door state on "E" press
            isOpen = !isOpen;
        }

        // Move the door towards the target position based on the door state
        Vector3 target = isOpen ? targetPosition : initialPosition;
        transform.position = Vector3.Lerp(transform.position, target, slidingSpeed * Time.deltaTime);
    }

    // Method to open the door when the correct passcode is entered
    public void OpenDoor()
    {
        isLocked = false;
    }
}
