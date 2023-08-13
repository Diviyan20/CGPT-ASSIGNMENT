using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsNearDoor())
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

