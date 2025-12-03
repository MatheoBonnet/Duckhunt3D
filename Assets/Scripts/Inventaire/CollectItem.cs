using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public InventorySO inventaire;
    public ItemData item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventaire.addItem(item);
            Destroy(gameObject);
        }
    }
}
