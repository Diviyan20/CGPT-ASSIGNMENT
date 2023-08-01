using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSens = 5f;
    public Transform Body;

    float xRotation = 0f;
	private bool canLook = true;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
		if (canLook && Time.timeScale > 0f)
		{
			float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens;
			float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens;

			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);
			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        

			Body.Rotate(Vector3.up * mouseX); 
		}
    }
	public void SetCameraMovement(bool canMove)
	{
		canLook = canMove;
	}
}
