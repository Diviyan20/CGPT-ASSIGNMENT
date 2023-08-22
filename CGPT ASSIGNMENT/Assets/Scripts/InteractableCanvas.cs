using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCanvas : MonoBehaviour
{
    public GameObject canvasObject;
	public GameObject canvasObject2;

    [SerializeField] private Transform raycastPoint; // Reference to the GameObject that will be the origin of the raycast.

    private void Update()
{
    // Perform raycast to detect interactable items
    RaycastHit hit;
    if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit))
    {
        // Log the name of the hit object for debugging purposes
        Debug.Log("Hit Object: " + hit.collider.gameObject.name);

        // Check if the detected object is interactable (based on the tag)
        if (hit.collider.CompareTag("Interactable"))
        {
            // Show the canvas when pointing at an interactable item
            canvasObject.SetActive(true);
			canvasObject2.SetActive(false);
        }
		
		else if (hit.collider.CompareTag("Wooden Door"))
		{
            // Show the canvas when pointing at an interactable item
            canvasObject.SetActive(false);
			canvasObject2.SetActive(true);
        }
		
        else
        {
            // Hide the canvas when not pointing at an interactable item
            canvasObject.SetActive(false);
			canvasObject2.SetActive(false);
        }
    }
    else
    {
        // Log that the raycast did not hit any object for debugging purposes
        Debug.Log("Raycast did not hit any object");

        // Hide the canvas when not pointing at anything
        canvasObject.SetActive(false);
    }
}
}

