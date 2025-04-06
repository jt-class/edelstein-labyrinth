using UnityEngine;

public class OrbAbility : AbilityBase
{
    private int energyOrbs = 1;

    private void Start()
    {
        abilityType = AbilityType.Orb;
    }

    protected override void ApplyUpgrade()
    {
        energyOrbs = level * 2;
        Debug.Log($"Orb upgraded to Level {level}: Energy Orbs = {energyOrbs}");
    }

    public override void UseAbility()
    {
        Debug.Log($"Using Orb Ability with {energyOrbs} orbs.");
    }
}
