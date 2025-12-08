using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public InventorySO inventaire;
    public ItemData item;

    public bool collectable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter(Collider other)
    {
        if (collectable)
        {
            if (other.CompareTag("Player"))
            {
                inventaire.addItem(item);
                Destroy(gameObject);
            }
        }
        
    }
}
