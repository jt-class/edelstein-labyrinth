using UnityEngine;

public class RadianceAbility : MonoBehaviour
{
    public float auraRadius = 3f;
    public float damageMultiplier = 0.5f;
    private float nextTickTime;

    void Update()
    {
        if (Time.time >= nextTickTime)
        {
            ApplyRadianceDamage();
            nextTickTime = Time.time + 1f;
        }
    }

    void ApplyRadianceDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, auraRadius);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>()?.TakeDamage(damageMultiplier);
            }
        }
    }

    public void UpgradeAbility(int level)
    {
        damageMultiplier += 0.1f * level;
        auraRadius += 0.5f * level;
    }
}

