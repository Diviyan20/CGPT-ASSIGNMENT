using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public NoteController noteController;   

    private void Start()
    {
        noteController = FindObjectOfType<NoteController>();
    }

    public void OnExitButtonClicked()
    {
        noteController.ExitNote();
    }
}
