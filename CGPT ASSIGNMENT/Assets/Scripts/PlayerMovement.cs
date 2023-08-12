using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    private bool isMoving;
    public float gravity = -9f;
    public int keys = 0;
    Vector3 velocity;
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

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isMoving = (x != 0f || z != 0f);     
    }

   public void ObtainKey()
    {
        keys += 1;
    }

}
