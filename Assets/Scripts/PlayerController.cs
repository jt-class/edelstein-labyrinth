using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    //Variables
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject levelUpCanvas;
    [SerializeField] public GameObject HealthBar;
    [SerializeField] public GameObject ExternalUI;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    
    private Slider HealthSlider;
    private Slider ExpSlider;
    

    // Projectile
    [SerializeField] private GameObject arrowObject;
    private bool canShoot = true;
    private float shootCooldown = 1f;

    // Movement
    private Vector2 lastMovementDirection;

    // Player Variables
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int level = 0;
    private int currentHealth;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        HealthSlider = HealthBar.GetComponent<Slider>();
        ExpSlider = ExternalUI.GetComponent<Slider>();
        
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        fireProjectile();

        if (Input.GetKey(KeyCode.P))
        {
            LevelUp();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            FireContinuousProjectiles(); //pa ni pinindot yung space sheesh god mode attack for testing lang
        }

        if (Input.GetKey(KeyCode.X))
        {
            NormalContinuousProjectiles(); //pa ni pinindot yung x normal attack lang pero 5 bullets
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
        if (movement.x < 0) { mySpriteRender.flipX = true; }
        else if (movement.x > 0) { mySpriteRender.flipX = false; }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage received: " + damage + " Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            HealthSlider.maxValue = maxHealth;
            HealthSlider.value = currentHealth;
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
            TakeDamage(5);
        }
    }

    private void fireProjectile()
    {
        if (canShoot && lastMovementDirection != Vector2.zero)
        {
            canShoot = false;

            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = fireDirection * 5.0f;
            Destroy(projectile_arrow, 2f);

            StartCoroutine(ShootCooldown());
        }
    }

    private void FireContinuousProjectiles()
    {
        if (lastMovementDirection != Vector2.zero)
        {
            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = fireDirection * 5.0f; //dito iaadjust yung bilis ng bullets
            Destroy(projectile_arrow, 2f);
        }
    }

    private void NormalContinuousProjectiles()
    {
        if (lastMovementDirection != Vector2.zero)
        {
            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = fireDirection * 1.0f; //dito iaadjust yung bilis ng bullets
            Destroy(projectile_arrow, 2f);
        }
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    public void LevelUp()
    {
        levelUpCanvas.SetActive(true);
        
    }

}