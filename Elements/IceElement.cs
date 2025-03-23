using UnityEngine;

public class IceElement : ElementInfusion
{
    private float slowEffectPercent = 0.05f;

    private void Start()
    {
        elementType = ElementType.Ice;
    }

    protected override void ApplyUpgrade()
    {
        float[] slowEffectStages = { 0.05f, 0.12f, 0.25f, 0.35f, 0.50f };
        slowEffectPercent = slowEffectStages[Mathf.Clamp(level - 1, 0, 4)];
        Debug.Log($"Ice Infusion upgraded! Slows enemy movement by {slowEffectPercent * 100}%.");
    }

    public override void ApplyEffect(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.ApplySlow(slowEffectPercent); // Slows enemy instead of direct damage
        }
    }
}
