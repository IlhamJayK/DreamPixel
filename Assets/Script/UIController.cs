using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
   public TMP_Dropdown resolutionDropdown;
   
   public Slider _musicSlider, _sfxSlider;

   Resolution[] resolutions;
   
   private void Start() {
      resolutions = Screen.resolutions;

      resolutionDropdown.ClearOptions();

      List<string> options = new List<string>();

      for (int i = 0; i < resolutions.Length; i++){

         string option = resolutions[i].width + " x " + resolutions[i].height;
         options.Add(option);
      }

      resolutionDropdown.AddOptions(options);

   }
   
   public void MusicVolume()
   {
    AudioManagers.Instance.MusicVolume(_musicSlider.value);
   }

   public void SFXVolume(){
    AudioManagers.Instance.SfxVolume(_sfxSlider.value);
   }

   public void Fullscreen(bool isFullscreen){
      Screen.fullScreen = isFullscreen;
   }
}
