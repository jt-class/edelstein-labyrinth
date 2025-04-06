using UnityEngine;

public enum AbilityType { Orb, Trap, Pixie, Shield, Radiance }

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] protected AbilityType abilityType;
    [SerializeField] protected int level = 0;
    private const int maxLevel = 5;

    public virtual void Upgrade()
    {
        level = Mathf.Min(level + 1, maxLevel);
        ApplyUpgrade();
    }

    protected abstract void ApplyUpgrade();
    public abstract void UseAbility();
}

