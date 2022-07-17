using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 playerPosition;
    public float velocityX;
    public float velocityY;
    private Rigidbody2D rb;

    //Input variables
    private PlayerInputActions playerInputActions;
    private InputAction movementY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocityX, 0);
        playerPosition = transform.position;

    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.movementY.performed += DoSpeedY;
        playerInputActions.Player.movementY.Enable();
    }

    private void DoSpeedY(InputAction.CallbackContext obj)
    {
        rb.velocity += new Vector2(0, velocityY);
    }

    private void OnDisable()
    {
        playerInputActions.Player.movementY.Disable();
    }

    private void Update()
    {
        rb.velocity += new Vector2(0.001f,0);

    }
}
