using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform upperPosition;         // The player position above the slant.
    public Transform lowerPosition;         // The player position below the slant.

    private GameObject player;              // The player.
    private Animator anim;                  // The player animator.
    private Vector2 lastTouchPosition;      // The finger position in pixel coordinates from the latest touch control.
    private bool aboveSlant = true;         // Used to switch to above or below the slant.
    private bool isSwiping = false;         // Is a swipe control in progress?

    /* Use this for initialization. */
    private void Start()
    {
        player = gameObject;
        anim = player.GetComponent<Animator>();
        lastTouchPosition = new Vector2();
    }

    /* Update is called once per frame. */
    private void Update()
    {
    #if UNITY_ANDROID
        // Return if the player isn't touching the screen.
        if (Input.touchCount == 0)
            return;
        
        // If time has pasted since the last recorded touch value changes.
        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (!isSwiping)
            {
                lastTouchPosition = Input.GetTouch(0).position;
                isSwiping = true;
                return;
            }
            else
            {
                Vector2 direction = Input.GetTouch(0).position - lastTouchPosition;
                if (direction.x > 0)
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
                else if (direction.x < 0)
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
        }
        else
        {
            isSwiping = false;
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