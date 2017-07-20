using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;             // The canvas group that controls the fade image alpha.

    private float loadTime;                         // The time it takes to load the scene.
    private float minimumLogoTime = 3.0f;           // The minimum amount of time the logo must be shown.

    /* Use this for initialization. */
    void Start()
    {
        // Get the fade canavs group if not set in the editor.
        if (!fadeCanvasGroup)
        {
            fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
        }

        // The fade begins with a white screen.
        fadeCanvasGroup.alpha = 1.0f;

        // Preload assests...

        // For fast load times allow logo to remain for minimum period.
        if (Time.time < minimumLogoTime)
        {
            loadTime = minimumLogoTime;
        }
        else
        {
            loadTime = Time.time;
        }
    }

    /* Update is called once per frame. */
    void Update()
    {
        // Fade-in.
        if (Time.time < minimumLogoTime)
        {
            fadeCanvasGroup.alpha = 1 - Time.time;
        }

        // Fade-out.
        if (Time.time > minimumLogoTime && loadTime != 0.0f)
        {
            fadeCanvasGroup.alpha = Time.time - minimumLogoTime;
            if (fadeCanvasGroup.alpha >= 1.0f)
            {
                Debug.Log("Change the scene");
            }
        }
    }
}