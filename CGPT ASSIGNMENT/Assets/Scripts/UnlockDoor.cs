using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject key;
    [SerializeField] private Transform raycastPoint;


    private void Start()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Unlock()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit))
        {
            if (IsNearDoor())
            {
                if(hit.collider.CompareTag("Door"))
                Destroy(door);
            }
        }
    }



    private bool IsNearDoor()
     {
            float distance = Vector3.Distance(player.transform.position, door.transform.position);
            float unlockDistance = 2.0f;

            return distance <= unlockDistance;
        }

    }

