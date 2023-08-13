using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene = "ROOM 2";
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    private Animator anim;

    private void Start()
    {
        anim = anim.GetComponent<Animator>(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsNearDoor())
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private bool IsNearDoor()
    {
        float distance = Vector3.Distance(player.transform.position, door.transform.position);
        float unlockDistance = 2.0f;

        return distance <= unlockDistance;
    }
}

