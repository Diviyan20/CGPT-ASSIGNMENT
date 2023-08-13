using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if(door == null)
        {
            door = GameObject.FindGameObjectWithTag("Door");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsNearKey())
        {
            UnlockDoor unlock = door.GetComponent<UnlockDoor>();

            if(unlock!=null)
            {
                unlock.Unlock();
            }
           
        }
    }

    private bool IsNearKey()
    {
        float distance = Vector3.Distance(transform.position,player.transform.position);
        float PickupDistance = 2.0f;

        return distance <= PickupDistance;
    }

    public void KeyCollected()
    {
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
}
