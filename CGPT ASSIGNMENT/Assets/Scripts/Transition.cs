using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator anim;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

   

}
