using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float baseSize;
    public int baseMaxHealth = 10;
    public float currentHealth;

    private float bonusHealth, bonusSize, realMaxHealth, realSize;


    public InventorySO inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = baseMaxHealth;
        bonusSize = inventory.GetBonusTotal(StatType.duckSize);
        bonusHealth = inventory.GetBonusTotal(StatType.duckHealth);
        realMaxHealth = baseMaxHealth + bonusHealth;
        transform.localScale += new Vector3(bonusSize, bonusSize, bonusSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
