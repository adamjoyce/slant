using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public float moveSpeed;                 // The speed at which the terrain travels.

    private Rigidbody2D rb;                 // The terrains rigidbody used for movement.
    private Vector3 movement;               // The movement vector for the terrain.

    /* Use this for initialization. */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /* FixedUpdate is called once per frame after Update. */
    void FixedUpdate()
    {
        movement = -transform.right * moveSpeed;
        rb.MovePosition(transform.position + movement * Time.deltaTime);
    }
}