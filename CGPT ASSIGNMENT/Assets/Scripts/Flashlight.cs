using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private AudioSource flashlightSound;
    public bool on;
    public bool off;
    
    void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(off && Input.GetButtonDown("F"))
        {
            flashlightSound.Play();
            flashlight.SetActive(true);
            on = true;
            off = false;
        }

       else if(on && Input.GetButtonDown("F"))
        {
            flashlightSound.Play();
            flashlight.SetActive(false);
            on = false;
            off = true;
        }
    }
}
