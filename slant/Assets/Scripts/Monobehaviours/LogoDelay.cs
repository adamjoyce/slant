using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoDelay : MonoBehaviour
{
    public float logoWaitTime = 3.0f;              // The time in seconds the logo should be displayed before changing scenes.

    /* Use this for initialization. */
    private IEnumerator Start()
    {
        SceneController sceneController = FindObjectOfType<SceneController>();
        yield return new WaitForSeconds(logoWaitTime);
        sceneController.FadeAndLoadScene("Game");
    }
}