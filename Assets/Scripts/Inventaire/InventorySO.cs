using System.Collections.Generic;
using UnityEngine;

public class InventorySO : ScriptableObject
{
    public List<ItemData> itemsPossedes = new List<ItemData>();

    public float GetBonusTotal(StatType typeDeStat)
    {
        float total = 0;
        
        foreach (var item in itemsPossedes)
        {
            foreach (var mod in item.bonusSats)
            {
                if (mod.statConcernee == typeDeStat)
                {
                    total += mod.valeur;
                }
            }
        }
        return total;
    }

    public void addItem(ItemData item)
    {
        itemsPossedes.Add(item);
    }
    public void removeItem(ItemData item) { 
        itemsPossedes.Remove(item); 
    }
    public void clearInventory()
    {
        foreach (var item in itemsPossedes)
        {
            removeItem(item);
        }
    }
}