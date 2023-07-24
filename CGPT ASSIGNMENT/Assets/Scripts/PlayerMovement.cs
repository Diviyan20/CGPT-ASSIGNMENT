using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    private bool isMoving;

    public bool IsMoving()
    {
        return isMoving;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        controller.Move(dir * speed * Time.deltaTime);

        // Check if the player is moving
        isMoving = (x != 0f || z != 0f);
    }
}
