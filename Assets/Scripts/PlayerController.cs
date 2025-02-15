using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;

    // Arrow
    [SerializeField] private GameObject arrowObject;


    private void Awake()
    {
        playerControls = new PlayerControls();                      // REFERENCE TO PLAYER CONTROL INPUT (PLUGIN)
        rb = GetComponent<Rigidbody2D>();                           // REFERENCE TO RIGID BODY
        myAnimator = GetComponent<Animator>();                      // REFERENCE TO ANIMATION CONTROLLER
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);

            // Use flipX to check the player's facing direction
            float facingDirection = mySpriteRender.flipX ? -1f : 1f;

            // Set the velocity based on the facing direction
            projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(facingDirection * 2.0f, 0.0f);
        }

    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()                      // CHANGE THIS TO LAST MOVE DIRECTION IF KAILANGAN
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
        }
        else
        {
            mySpriteRender.flipX = false;
        }
    }
}
