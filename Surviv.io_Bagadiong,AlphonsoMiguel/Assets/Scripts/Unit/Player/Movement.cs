using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Components")]
    public float moveSpeed;
    Vector2 movement;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // initializing movement

        movement.x = PlayerManager.Instance.pMoveJoystick.Horizontal;
        movement.y = PlayerManager.Instance.pMoveJoystick.Vertical;

    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
