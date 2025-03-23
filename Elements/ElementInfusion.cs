using UnityEngine;

public enum ElementType { Fire, Electric, Ice }

public abstract class ElementInfusion : MonoBehaviour
{
    [SerializeField] public ElementType elementType;
    [SerializeField] protected int level = 0;
    private const int maxLevel = 5;

    public virtual void Upgrade()
    {
        level = Mathf.Min(level + 1, maxLevel);
        ApplyUpgrade();
    }

    protected abstract void ApplyUpgrade();
    public abstract void ApplyEffect(GameObject target);
}

