using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float baseAttack = 20f;
    private BuffManager buffManager;
    private PlayerElements elementManager;

    private void Start()
    {
        buffManager = GetComponent<BuffManager>();
        elementManager = GetComponent<PlayerElements>();
    }

    public void Attack(GameObject enemy)
    {
        float abilityMultiplier = 1.5f; // Example ability boost (change per ability)
        float elementMultiplier = 1.0f;
        float buffMultiplier = buffManager.GetBuffMultiplier();

        if (elementManager != null)
        {
            elementManager.UseElement(enemy);
        }

        float finalDamage = DamageManager.CalculateDamage(baseAttack, abilityMultiplier, elementMultiplier, buffMultiplier, 0.1f);
        enemy.GetComponent<Enemy>()?.TakeDamage(finalDamage);
    }
}
