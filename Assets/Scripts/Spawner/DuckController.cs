using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float baseSize;
    public float baseHealth;

    private float bonusHealth, bonusSize, realHealth, realSize;


    public InventorySO inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bonusSize = inventory.GetBonusTotal(StatType.duckSize);
        bonusHealth = inventory.GetBonusTotal(StatType.duckHealth);
        realHealth = baseHealth + bonusHealth;
        transform.localScale += new Vector3(bonusSize, bonusSize, bonusSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
