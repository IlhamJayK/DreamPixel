using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeRemoveBehaviourRock : StateMachineBehaviour
{
    public float fadeTime = 0.8f;
    private float timeElapsed = 0f;
    SpriteRenderer spriteRenderer;
    GameObject objToRemove;
    Color startColor;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed = 0;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        objToRemove = animator.gameObject;
        startColor = spriteRenderer.color;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed += Time.deltaTime;
        float newAlpha = startColor.a * (1 - (timeElapsed / fadeTime));
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if (timeElapsed >= fadeTime)
        {
            // Memanggil respawn melalui TreeManager
            RockRespawn.Instance.RequestRespawn(objToRemove.transform.position);
            Destroy(objToRemove);
        }
    }
}
