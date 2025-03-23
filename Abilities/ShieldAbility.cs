using UnityEngine;
using System.Collections;

public class ShieldAbility : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float regenTime = 45f;
    private bool shieldActive = true;
    private GameObject shieldInstance;

    void Start()
    {
        ActivateShield();
    }

    public void ActivateShield()
    {
        if (shieldActive) return;

        shieldActive = true;
        shieldInstance = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
        StartCoroutine(RemoveShield());
    }

    private IEnumerator RemoveShield()
    {
        yield return new WaitForSeconds(5f);
        Destroy(shieldInstance);
        shieldActive = false;
        Invoke(nameof(ActivateShield), regenTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack") && shieldActive)
        {
            shieldActive = false;
            Destroy(shieldInstance);
            ActivateShockwave();
        }
    }

    void ActivateShockwave()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>()?.TakeDamage(0.1f);
            }
        }
    }

    public void UpgradeAbility(int level)
    {
        regenTime -= 5f * level;
    }
}

