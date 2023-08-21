using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject Invkey;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource PickupSound;
    void Start()
    {
        Invkey.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && IsNearKey())
        {
            key.SetActive(false);
            PickupSound.Play();
            Invkey.SetActive(true);
        }
    }

    private bool IsNearKey()
    {
         float distance = Vector3.Distance(player.transform.position, key.transform.position);
         float unlockDistance = 2.0f;

         return distance <= unlockDistance;
    }
}
