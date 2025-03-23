using UnityEngine;

public class ArrowChase : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 initialDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target, Vector2 initialDirection)
    {
        this.target = target;
        this.initialDirection = initialDirection.normalized;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = initialDirection * moveSpeed;
        }
    }
}
