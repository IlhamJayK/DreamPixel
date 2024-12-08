using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGames : MonoBehaviour
{
    
    public Animator transition;
    
    public void PlayGame(){

        StartCoroutine(LevelLoader());

    }

    IEnumerator LevelLoader() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Intro");
    }

    public void CharacterSelect(){
        SceneManager.LoadScene("CharacterSelection");

    }

    public void Exit (){

        Application.Quit();

    }
    
    public void ExitMenu (){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Pause(){
        Time.timeScale = 0;
    }
    public void ExitPause(){
        Time.timeScale = 1;
    }
}
