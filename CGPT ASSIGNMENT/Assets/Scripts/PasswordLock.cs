using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordLock : MonoBehaviour
{
    [SerializeField] private Text password;
    private string answer = "1234";

    // Update is called once per frame
    public void Answer(int answer)
    {
        password.text += answer.ToString();
    }

    public void Execute()
    {
        Debug.Log(password.text);
        if(password.text.TrimStart()==answer)
        {
            password.text = "CORRECT!";
        }
        else
        {
            password.text = "WRONG!";
        }
    }
}
