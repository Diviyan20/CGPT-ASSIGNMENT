using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject door;
    [SerializeField] private Transform raycastPoint;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit))
            {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Wooden Door"))
            {
                LoadNextScene();
            }
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
           
    }
}

