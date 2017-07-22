using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform upperPosition;         // The player position above the slant.
    public Transform lowerPosition;         // The player position below the slant.

    private GameObject player;              // The player.
    private Animator anim;                  // The player animator.
    private bool aboveSlant = true;         // Used to switch to above or below the slant.

    /* Use this for initialization. */
    private void Start()
    {
        player = gameObject;
        anim = player.GetComponent<Animator>();
    }

    /* Update is called once per frame. */
    private void Update()
    {
        #if UNITY_ANDROID
        Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
        if (deltaPosition.sqrMagnitude != 0)
        {
            // Swipe has occurred.
            if (Mathf.Sign(deltaPosition.x) > 0)
            {
                // Upwards Swipe.
                if (!aboveSlant)
                {
                    // Move to above the slant.
                    player.transform.SetPositionAndRotation(upperPosition.position, upperPosition.rotation);
                    anim.SetBool("aboveSlant", true);
                    aboveSlant = true;
                }
            }
            else if (Mathf.Sign(deltaPosition.x) < 0)
            {
                // Downwards Swipe.
                if (aboveSlant)
                {
                    // Move to below the slant.
                    player.transform.SetPositionAndRotation(lowerPosition.position, lowerPosition.rotation);
                    anim.SetBool("aboveSlant", false);
                    aboveSlant = false;
                }
            }
        }
        #endif

        #if UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (aboveSlant)
            {
                // Move to below the slant.
                player.transform.SetPositionAndRotation(lowerPosition.position, lowerPosition.rotation);
                anim.SetBool("aboveSlant", false);
                aboveSlant = false;
            }
            else
            {
                // Move to above the slant.
                player.transform.SetPositionAndRotation(upperPosition.position, upperPosition.rotation);
                anim.SetBool("aboveSlant", true);
                aboveSlant = true;
            }
        }
        #endif
    }
}