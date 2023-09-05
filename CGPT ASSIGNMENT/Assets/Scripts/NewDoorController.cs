using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoorController : MonoBehaviour
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
        if (requiredKey.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
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
}
