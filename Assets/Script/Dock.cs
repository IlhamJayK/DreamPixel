using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dock : MonoBehaviour
{
    public Animator transition;
    
    bool playerIsClose;
    public GameObject E;

    public string scenename;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true){

            StartCoroutine(LevelLoader());

        }
    }

    IEnumerator LevelLoader() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scenename);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            E.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            E.SetActive(false);
        }
    }
}
