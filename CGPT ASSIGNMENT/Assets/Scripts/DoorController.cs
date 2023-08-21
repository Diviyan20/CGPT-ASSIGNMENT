using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject requiredKey;
    [SerializeField] private AudioSource unlockSound;
    public bool isLocked;
    public bool isOpen;

    private void Start()
    {
        isLocked = true;
        isOpen = false;
    }
    private void Update()
    {
        // Toggle door state on "E" press if it's not locked
        if (requiredKey.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E) && IsNearDoor())
        {
            isLocked = false;
            isOpen =true;
            unlockSound.Play();
            door.SetActive(false);
        }

        else
        {
            isLocked = true;
            isOpen = false;
        }
    }

    // Method to open the door when the correct passcode is entered
    public void OpenDoor()
    {
        isLocked = false;
    }

    private bool IsNearDoor()
    {
        float distance = Vector3.Distance(player.transform.position, door.transform.position);
        float unlockDistance = 2.0f;

        return distance <= unlockDistance;
    }
}
