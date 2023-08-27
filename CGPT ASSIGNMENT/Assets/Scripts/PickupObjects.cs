using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Transform Object;
    [Space]
    [SerializeField] private float PickupDistance;
    private Rigidbody currentObject;
    private bool isHolding = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!isHolding)
            {
                if(Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,Mathf.Infinity,PickupMask))
                {
                    PickupObject(hit.rigidbody);
                }
            }

            else
            {
                Dropobject();
            }
        }
    }

    private void PickupObject(Rigidbody objectRigidbody)
    {
        currentObject = objectRigidbody;
        currentObject.useGravity = false;
        isHolding = true;
    }

    private void Dropobject()
    {
        currentObject.useGravity = true;
        currentObject = null;
        isHolding = false;

    }

     void FixedUpdate()
    {
         if(isHolding)
        {
            Vector3 desiredPosition = MainCamera.transform.position + MainCamera.transform.forward * PickupDistance;
            currentObject.velocity = (desiredPosition - currentObject.position) / Time.fixedDeltaTime;
            currentObject.angularVelocity = Vector3.zero;
        }
    }
}

