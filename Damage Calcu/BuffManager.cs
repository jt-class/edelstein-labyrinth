using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private float attackBuff = 1.0f; // Default: No buff

    public void ApplyBuff(float multiplier, float duration)
    {
        attackBuff *= multiplier;
        Invoke(nameof(RemoveBuff), duration);
    }

    private void RemoveBuff()
    {
        attackBuff = 1.0f;
    }

    public float GetBuffMultiplier()
    {
        return attackBuff;
    }
}
