using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public void PlayRun(){
        AudioManagers.Instance.PlaySFX("Run");
    }

    public void Hit(){
        AudioManagers.Instance.PlaySFX("Hit");
    }

    public void Destroy(){
        AudioManagers.Instance.PlaySFX("Destroy");
    }
    
}
