using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;

public class PlayerManager : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public ParallaxEffect parallaxEffect, parallaxEffect2, parallaxEffect3, parallaxEffect4, parallaxEffect5; 
    public static Vector3 startPosition = new Vector3(-23, -3);

    public GameObject[] playerPrefabs;
    public GameObject player;
    int characterIndex;

    private void Awake() {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        player = Instantiate(playerPrefabs[characterIndex], startPosition, Quaternion.identity);

        vCam.m_Follow = player.transform;

        if (parallaxEffect != null)
        {
            parallaxEffect.followTarget = player.transform; 
            parallaxEffect2.followTarget = player.transform; 
            parallaxEffect3.followTarget = player.transform; 
            parallaxEffect4.followTarget = player.transform; 
            parallaxEffect5.followTarget = player.transform; 
        }

    }
}
