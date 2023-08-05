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
    private bool DialogueActive = true;
    [SerializeField] private AudioSource voiceOver;
    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        textComponent.text = string.Empty;
        BeginDialogue();
    }

    private void Update()
    {
        if (DialogueActive) // Only process input if the dialogue is active
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
                    voiceOver.Play();
                }
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
            DialogueActive = true;
        }

        else
        {
            gameObject.SetActive(false);
            player.enabled = true;
        }
    }
}
