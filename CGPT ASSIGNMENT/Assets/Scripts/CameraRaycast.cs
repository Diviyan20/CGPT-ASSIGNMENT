using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float RayLength = 5f;
    private Camera _camera;

    private NoteController note_controller;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;
    [Header("Input Key")]
    [SerializeField] private KeyCode InteractKey;

     void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
       if(Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f)),transform.forward, out RaycastHit hit, RayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if(readableItem!=null)
            {
                note_controller=readableItem;
                CrosshairColor(true);
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }

       if(note_controller!=null)
        {
            if(Input.GetKeyDown(InteractKey))
            {
                note_controller.ShowNote();
            }
        }
    }
    
    void ClearNote()
    {
        if(note_controller != null)
        {
            CrosshairColor(false);
            note_controller = null;
        }
    }

    void CrosshairColor(bool on)
    {
        if(on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }



}
