using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;

    private PlayerInput playerInput;
    private Vector2 movementInput;
    private Vector2 lookInput;
    private bool interactInput;

    void Awake()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions.FindAction("Move").performed += OnMove;
        playerInput.actions.FindAction("Look").performed += OnLook;
        playerInput.actions.FindAction("Interact").performed += OnInteract;
    }

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (inReach)
        {
            if (context.started)
            {
                noteUI.SetActive(true);
                pickUpSound.Play();
                hud.SetActive(false);
                inv.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (context.canceled)
            {
                ExitButton();
            }
        }
    }

    void Update()
    {
        if (playerInput.currentActionMap.enabled)
        {
            // Apply movement and look input to the player
            MovePlayer();
            LookPlayer();
        }
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        moveDirection = player.transform.TransformDirection(moveDirection);
        player.GetComponent<CharacterController>().SimpleMove(moveDirection * 5f); // You can adjust the movement speed as needed
    }

    private void LookPlayer()
    {
        Vector2 mouseDelta = lookInput * Time.deltaTime * 100f; // Adjust mouse sensitivity as needed
        Vector3 newRotation = player.transform.localEulerAngles + new Vector3(-mouseDelta.y, mouseDelta.x, 0f);
        player.transform.localEulerAngles = newRotation;
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
