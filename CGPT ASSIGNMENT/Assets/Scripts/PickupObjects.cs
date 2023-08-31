using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    [SerializeField] private LayerMask pickup;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Transform PickupObject;
    [Space]
    [SerializeField] private float PickupDistance;
    private Rigidbody currentObject;
    private bool isHolding = false;
    
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            if(!isHolding)
            {
                if(Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,Mathf.Infinity,pickup))
                {
                    CarryObject(hit.rigidbody);
                }
            }

            else
            {
                DropObject();
            }
        }
    }

    private void CarryObject(Rigidbody objectRigidbody)
    {
        currentObject = objectRigidbody;
        currentObject.useGravity = false;
        isHolding = true;
    }

    private void DropObject()
    {
        currentObject.useGravity = true;
        currentObject = null;
        isHolding = false;
    }

    void FixedUpdate()
    {
        Vector3 requiredposition = MainCamera.transform.position + MainCamera.transform.forward * PickupDistance;
        currentObject.velocity = (requiredposition - currentObject.position) / Time.fixedDeltaTime;
        currentObject.angularVelocity = Vector3.zero;
    }
}
