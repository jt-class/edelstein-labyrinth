using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int health = 3; // Health ng mga batugan na maliliit
    public bool isBoss = false; // yung boss obviously malaki tapos dapat iba kulay so...

    private float distance;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isBoss)
        {
            health = 100; // gawin nating 100 yung health babaan mo if masakit na sya masyado </3
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

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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
        if (isBoss)
        {
            Debug.Log("Boss hit! Remaining health: " + health);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
