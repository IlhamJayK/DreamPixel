using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManagers : MonoBehaviour
{
    public static AudioManagers Instance;
    
    public Sound[] musicSounds, sfxSounds, sfxSounds_;
    public AudioSource musicSource, sfxSource, SFXsource;

    
    private void Start() {
    string currentScene = SceneManager.GetActiveScene().name;
    PlayMusicForScene(currentScene);
}
private void OnEnable() {
    SceneManager.sceneLoaded += OnSceneLoaded;
}

private void OnDisable() {
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    PlayMusicForScene(scene.name);
}

    
    
    private void Awake() {
        if (Instance == null){

            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else{
            Destroy(gameObject);
        }
    }
    
    public void PlayMusic (string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null){

            Debug.Log("Not Found");


        }else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }


    }

    public void PlaySFX (string name)
        {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null){

            Debug.Log("Not Found");


        }else{
            sfxSource.PlayOneShot(s.clip);
        }


    }

    public void PlaySFX2 (string name)
        {
        Sound s = Array.Find(sfxSounds_, x => x.name == name);
        if (s == null){

            Debug.Log("Not Found");


        }else{
            sfxSource.Play();
        }


    }

    public void MusicVolume(float volume){
        
        musicSource.volume = volume;
    }
     public void SfxVolume(float volume){
        
        sfxSource.volume = volume;
    }
    
    public void PlayMusicForScene(string sceneName) {
    switch (sceneName) {
        case "Prototype":
            PlayMusic("Level1");
            break;
        case "Fall":
            PlayMusic("Fall");
            break;
        case "Magic":
            PlayMusic("Magical");
            break;
        case "MainMenu":
            PlayMusic("MainMenuTheme");
            break;
        case "CharacterSelection":
            PlayMusic("CharacterSelect");
            break;
        default:
            Debug.Log("No music assigned for this scene");
            musicSource.Stop();
            break;
    }
}

}

