using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static float CalculateDamage(float baseDamage, float abilityMultiplier, float elementMultiplier, float buffMultiplier, float enemyResistance)
    {
        // Base damage calculation
        float damage = baseDamage * abilityMultiplier;

        // Apply elemental effects
        damage *= elementMultiplier;

        // Apply buffs
        damage *= buffMultiplier;

        // Apply enemy resistance (resistance should be between 0-1, where 0.2 = 20% resistance)
        damage *= (1 - enemyResistance);

        return Mathf.Max(damage, 1); // Ensure minimum 1 damage
    }
}
