using UnityEngine;
using System.Collections.Generic;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> abilities = new List<AbilityBase>();

    public void AddAbility(AbilityBase ability)
    {
        if (abilities.Count < 2)
        {
            abilities.Add(ability);
            Debug.Log($"Added {ability.abilityType} ability!");
        }
        else
        {
            Debug.Log("Max 2 abilities allowed per match!");
        }
    }

    public void UpgradeAbility(AbilityType type)
    {
        AbilityBase ability = abilities.Find(a => a.abilityType == type);
        ability?.Upgrade();
    }
}
