using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Interactable;
    [SerializeField] private Transform RaycastPoint;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(RaycastPoint.position, RaycastPoint.forward, out hit))
        {
            // Log the name of the hit object for debugging purposes
            // Check if the detected object is interactable (based on the tag)
            if (hit.collider.CompareTag("Wooden Door"))
            {
                // Show the canvas when pointing at an interactable item
                canvas.SetActive(true);
                canvas = hit.collider.gameObject;
                Debug.Log("You are currentlt at the door to the next level");
            }
            else
            {
                // Hide the canvas when not pointing at an interactable item
                canvas.SetActive(false);
                canvas = null;
            }

        }

        else
        {
            Debug.Log("Raycast did not hit the door to the next level.");
            canvas.SetActive(false);
            Interactable = null;
        }
    }
}
