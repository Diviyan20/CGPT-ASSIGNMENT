using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public NoteController noteController;
    public TimeController timer;
   

    private void Start()
    {
        timer = FindObjectOfType<TimeController>();
        noteController = FindObjectOfType<NoteController>();
    }

    public void OnExitButtonClicked()
    {
        noteController.ExitNote();
        timer.StartTimer();
    }
}
