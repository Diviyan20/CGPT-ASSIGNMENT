using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject InvKey;
    [SerializeField] private AudioSource PickupSound;


    private void Start()
    {
        InvKey.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsNearKey())
        {
            key.SetActive(false);
            PickupSound.Play();
            InvKey.SetActive(true);
        }
    }

    private bool IsNearKey()
    {
        float distance = Vector3.Distance(player.transform.position, key.transform.position);
        float pickupkDistance = 2.0f;

        return distance <= pickupkDistance;
    }
}

