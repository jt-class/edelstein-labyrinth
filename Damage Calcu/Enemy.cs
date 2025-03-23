using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float resistance = 0.1f; // 10% damage resistance

    public void TakeDamage(float damageMultiplier)
    {
        float baseDamage = 10f; // Example base damage
        float finalDamage = DamageManager.CalculateDamage(baseDamage, 1f, damageMultiplier, 1f, resistance);

        health -= finalDamage;
        Debug.Log($"Enemy took {finalDamage} damage! Remaining Health: {health}");
    }

    public void ApplySlow(float slowPercent)
    {
        Debug.Log($"Enemy slowed by {slowPercent * 100}%!");
        // Implement movement speed reduction here
    }
}
