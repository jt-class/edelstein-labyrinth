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

    // Projectile
    [SerializeField] private GameObject arrowObject;

    // Movement
    private Vector2 lastMovementDirection;


    // Player Variables
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;



    private void Awake()
    {
        playerControls = new PlayerControls();                      // REFERENCE TO PLAYER CONTROL INPUT (PLUGIN)
        rb = GetComponent<Rigidbody2D>();                           // REFERENCE TO RIGID BODY
        myAnimator = GetComponent<Animator>();                      // REFERENCE TO ANIMATION CONTROLLER
        mySpriteRender = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        StartCoroutine(TickingFunction());
    }

    private void Update()
    {
        PlayerInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lastMovementDirection != Vector2.zero)
            {
                GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
                projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = lastMovementDirection.normalized * 2.0f;
                Destroy(projectile_arrow, 2f);
            }
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
        if (movement != Vector2.zero)
        {
            lastMovementDirection = movement;
        }

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()           
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {mySpriteRender.flipX = true;} else {mySpriteRender.flipX = false;}
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage received: " + damage + " Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player Died!");
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            TakeDamage(10);
        }
    }
    private IEnumerator TickingFunction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            fireProjectile();
        }
    }
    private void fireProjectile()
    {
        GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
        projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = lastMovementDirection.normalized * 2.0f;
        Destroy(projectile_arrow, 2f);
    }
}
