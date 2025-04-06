using UnityEngine;

public class PixieAbility : AbilityBase
{
    public GameObject pixieProjectile;
    public float fireRate = 1f;
    public int pixieCount = 1;
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            UseAbility();
            nextFireTime = Time.time + (1f / fireRate);
        }
    }

    public override void UseAbility()
    {
        for (int i = 0; i < pixieCount; i++)
        {
            GameObject pixie = Instantiate(pixieProjectile, transform.position, Quaternion.identity);
            pixie.GetComponent<PixieProjectile>()?.Initialize(40f);
        }
    }

    protected override void ApplyUpgrade()
    {
        fireRate += 0.5f;
        pixieCount = 1 + (level / 2);
        Debug.Log($"Pixie Upgraded! Fire Rate: {fireRate}, Count: {pixieCount}");
    }
}
