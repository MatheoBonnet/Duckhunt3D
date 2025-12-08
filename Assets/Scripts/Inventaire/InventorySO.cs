using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventaireGlobal", menuName = "Système/Inventaire")]
public class InventorySO : ScriptableObject
{
    public List<ItemData> itemsPossedes = new List<ItemData>();

    // C'est la méthode MAGIQUE que tout le monde va appeler
    public float GetBonusTotal(StatType typeDeStat)
    {
        float total = 0;
        
        // On regarde chaque item dans le sac
        foreach (var item in itemsPossedes)
        {
            // On regarde chaque bonus de l'item
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
}