using UnityEngine;

public class TrapAbility : AbilityBase
{
    private int explosions = 1;

    private void Start()
    {
        abilityType = AbilityType.Trap;
    }

    protected override void ApplyUpgrade()
    {
        explosions = level;
        Debug.Log($"Trap upgraded to Level {level}: Explodes {explosions} times.");
    }

    public override void UseAbility()
    {
        Debug.Log($"Using Trap Ability, explodes {explosions} times.");
    }
}

