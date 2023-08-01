using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] text;
    public float dialogueSpeed;
    private int index;
    public CharacterController player;
    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        textComponent.text = string.Empty;
        BeginDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == text[index])
            {
                NextDialogue();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = text[index];
                player.enabled = true;
            }
        }
    }

    void BeginDialogue()
    {
        index = 0;
        player.enabled = false;
        StartCoroutine(TypeLine());
    }



    IEnumerator TypeLine()
    {
        foreach (char c in text[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogueSpeed);
        }
    }

    void NextDialogue()
    {
        if (index < text.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
