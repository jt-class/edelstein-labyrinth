using UnityEngine;

public class PlayerElements : MonoBehaviour
{
    [SerializeField] private ElementInfusion elementInfusion;

    public void InfuseElement(ElementInfusion element)
    {
        if (elementInfusion == null)
        {
            elementInfusion = element;
            Debug.Log($"Infused {element.elementType} Element!");
        }
        else
        {
            Debug.Log("You already have an Elemental Infusion!");
        }
    }

    public void UpgradeElement()
    {
        elementInfusion?.Upgrade();
    }

    public void UseElement(GameObject target)
    {
        elementInfusion?.ApplyEffect(target);
    }
}
