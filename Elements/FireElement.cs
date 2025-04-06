using UnityEngine;

public class FireElement : ElementInfusion
{
    private float burnDamagePercent = 0.05f;

    private void Start()
    {
        elementType = ElementType.Fire;
    }

    protected override void ApplyUpgrade()
    {
        float[] burnDamageStages = { 0.05f, 0.075f, 0.12f, 0.18f, 0.25f };
        burnDamagePercent = burnDamageStages[Mathf.Clamp(level - 1, 0, 4)];
        Debug.Log($"Fire Infusion upgraded! Burn Damage: {burnDamagePercent * 100}% per second.");
    }

    public override void ApplyEffect(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            float fireMultiplier = 1 + burnDamagePercent; // Tumataas burn damage
            enemy.TakeDamage(fireMultiplier);
        }
    }


}

