using System.Collections;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int health = 3; // Health ng mga batugan na maliliit
    public bool isBoss = false; // Yung boss obviously malaki tapos dapat iba kulay so...

    private float distance;
    private SpriteRenderer spriteRenderer;
    private Animator animator; // Animator component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Get Animator component

        if (isBoss)
        {
            health = 100; // Gawin nating 100 yung health babaan mo if masakit na sya masyado </3
        }
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;
        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Projectile"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        animator.SetTrigger("Hit");  // Play Hit animation

        StartCoroutine(FlashRed());  // Red flash effect

        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ResetHitState()); // Transition back to Idle after Hit
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red; // Change to red
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white; // Reset color
    }

    private IEnumerator ResetHitState()
    {
        yield return new WaitForSeconds(0.5f); // Adjust based on animation length
        animator.SetTrigger("Idle"); // Ensure transition back to Idle
    }

    private void Die()
    {
        Destroy(gameObject); // Destroy enemy
    }
}
