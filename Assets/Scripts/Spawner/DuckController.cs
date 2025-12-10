using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float baseSize;
    public int baseMaxHealth = 10;
    private float currentHealth;

    private float bonusHealth, bonusSize, realMaxHealth, realSize;

    public float baseReward;
    private float bonusReward, realReward;


    public InventorySO inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = baseMaxHealth;

        bonusHealth = inventory.GetBonusTotal(StatType.duckHealth);
        realMaxHealth = baseMaxHealth + bonusHealth;

        bonusSize = inventory.GetBonusTotal(StatType.duckSize);
        transform.localScale += new Vector3(bonusSize, bonusSize, bonusSize);

        bonusReward = inventory.GetBonusTotal(StatType.duckReward);
        realReward = baseReward + bonusReward;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            // player.GetComponent<Player>().score += realReward;
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
