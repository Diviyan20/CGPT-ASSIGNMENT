using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasObject;
    public PlayerMovement playerMovement;

    private bool isCanvasActive = true;
    private float movementTimer = 3f;

    private void Start()
    {
        // Get a reference to the player movement script
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isCanvasActive && playerMovement.IsMoving())
        {
            // Start the movement timer
            movementTimer -= Time.deltaTime;

            if (movementTimer <= 0f)
            {
                // Disable the canvas after 5 seconds of movement
                canvasObject.SetActive(false);
                isCanvasActive = false;
            }
        }
    }
}
