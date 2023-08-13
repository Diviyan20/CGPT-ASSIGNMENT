using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && NearKey())
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool NearKey()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        float pickupDistance = 2.0f;

        return distance <= pickupDistance;
    }
}
