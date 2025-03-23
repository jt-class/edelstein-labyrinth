using UnityEngine;

public class ElectricElement : ElementInfusion
{
    private float chainDamagePercent = 0.05f;

    private void Start()
    {
        elementType = ElementType.Electric;
    }

    protected override void ApplyUpgrade()
    {
        float[] chainDamageStages = { 0.05f, 0.12f, 0.15f, 0.10f, 0.50f };
        chainDamagePercent = chainDamageStages[Mathf.Clamp(level - 1, 0, 4)];
        Debug.Log($"Electric Infusion upgraded! Chain Damage: {chainDamagePercent * 100}% of attack.");
    }

    public override void ApplyEffect(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            float electricMultiplier = 1 + chainDamagePercent; // Electric chains 
            enemy.TakeDamage(electricMultiplier);
        }
    }
}

