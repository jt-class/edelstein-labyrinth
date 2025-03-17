/*using System.Collections;
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
    private bool canShoot = true;
    private float shootCooldown = 1f;

    // Movement
    private Vector2 lastMovementDirection;

    // Player Variables
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        fireProjectile();

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
            TakeDamage(2);
        }
    }

    private void fireProjectile()
    {
        if (canShoot && lastMovementDirection != Vector2.zero)
        {
            canShoot = false;

            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().velocity = fireDirection * 5.0f;
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
            projectile_arrow.GetComponent<Rigidbody2D>().velocity = fireDirection * 5.0f; //dito iaadjust yung bilis ng bullets
            Destroy(projectile_arrow, 2f);
        }
    }

    private void NormalContinuousProjectiles()
    {
        if (lastMovementDirection != Vector2.zero)
        {
            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().velocity = fireDirection * 1.0f; //dito iaadjust yung bilis ng bullets
            Destroy(projectile_arrow, 2f);
        }
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}*/ // uncomment nyo nalang toh then try nyo

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

    private bool isGodModeActive = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
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

            fireProjectile();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            isGodModeActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            isGodModeActive = false;
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
            yield return new WaitForSeconds(0.2f);
            if (isGodModeActive && lastMovementDirection != Vector2.zero)
            {
                GodMode();
            }
            fireProjectile();
        }
    }

    private void fireProjectile()
    {
        GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
        projectile_arrow.GetComponent<Rigidbody2D>().linearVelocity = lastMovementDirection.normalized * 2.0f;
        Destroy(projectile_arrow, 2f);
    }

    private void GodMode()
    {
        if (lastMovementDirection != Vector2.zero)
        {
            Vector2 fireDirection = lastMovementDirection.normalized;

            GameObject projectile_arrow = Instantiate(arrowObject, transform.position, Quaternion.identity);
            projectile_arrow.GetComponent<Rigidbody2D>().velocity = fireDirection * 5.0f;
            Destroy(projectile_arrow, 2f);
        }
    }

   public void DisableMovement()
    {
        playerControls.Disable();
    }

    public void EnableMovement()
    {
        playerControls.Enable();
    }
} //try nyo rin toh pag mag sasave kayo press nyo lang yung NO 

/*using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.Q))
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

    public void DisableMovement()
    {
        playerControls.Disable();
    }

    public void EnableMovement()
    {
        playerControls.Enable();
    }

} */