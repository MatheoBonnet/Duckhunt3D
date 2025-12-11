using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float baseSize;
    public int baseMaxHealth = 10;
    private float currentHealth;

    private float bonusHealth, bonusSize, realMaxHealth, realSize;

    public float baseScoreReward;
    private float bonusScoreReward, realScoreReward;

    public float baseMoneyReward;
    private float bonusMoneyReward, realMoneyReward;


    public InventorySO inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = baseMaxHealth;

        bonusHealth = inventory.GetBonusTotal(StatType.duckHealth);
        realMaxHealth = baseMaxHealth + bonusHealth;

        bonusSize = inventory.GetBonusTotal(StatType.duckSize);
        transform.localScale += new Vector3(bonusSize, bonusSize, bonusSize);

        bonusScoreReward = inventory.GetBonusTotal(StatType.duckScoreReward);
        realScoreReward = baseScoreReward + bonusScoreReward;

        bonusScoreReward = inventory.GetBonusTotal(StatType.duckMoneyReward);
        realMoneyReward = baseMoneyReward + bonusMoneyReward;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Player.updateScore(realScoreReward);
            Player.addMoney(realMoneyReward);
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
