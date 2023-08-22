using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    private bool isMoving;
    private bool isCrouching;
    private float originalHeight;
    public float gravity = -9f;
    Vector3 velocity;
    public bool IsMoving()
    {
        return isMoving;
    }

    private void Start()
    {
        originalHeight = controller.height;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        controller.Move(dir * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isMoving = (x != 0f || z != 0f);   
        
        if(Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            controller.height = originalHeight / 4;
        }

        else
        {
            isCrouching = false;
            controller.height = originalHeight;
        }

                
    }

}
