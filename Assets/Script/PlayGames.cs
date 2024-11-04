using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGames : MonoBehaviour
{
    public void PlayGame(){

        SceneManager.LoadScene(0);

    }

    public void Exit (){

        Application.Quit();

    }
        
}
