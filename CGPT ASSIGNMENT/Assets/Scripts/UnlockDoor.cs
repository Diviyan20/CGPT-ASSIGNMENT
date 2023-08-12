using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    public int requiredKey=1;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if(playerMovement!=null && Input.GetKeyDown(KeyCode.E) && IsNearDoor() && playerMovement.keys == requiredKey )
        {
            Destroy(door);
        }
    }



    private bool IsNearDoor()
     {
            float distance = Vector3.Distance(player.transform.position, door.transform.position);
            float unlockDistance = 2.0f;

            return distance <= unlockDistance;
        }

    }

