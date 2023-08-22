using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject requiredKey;
    [SerializeField] private AudioSource UnlockSound;
    public bool isOpen;
    public bool isLocked;

    private void Start()
    {
        isOpen = false;
        isLocked = true;

    }

    private void Update()
    {
        if(requiredKey.activeInHierarchy == true && IsNearDoor() && Input.GetKeyDown(KeyCode.E))
        {
            requiredKey.SetActive(false);
            UnlockSound.Play();
            isOpen = true;
            isLocked = false;
            door.SetActive(false);
        }

        else
        {
            door.SetActive(true);
            isLocked = true;
            isOpen = false;
        }
    }

    private bool IsNearDoor()
    {
        float distance = Vector3.Distance(player.transform.position, door.transform.position);
        float unlockDistance = 2.0f;

        return distance <= unlockDistance;
    }
}
