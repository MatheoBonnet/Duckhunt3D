using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StatModifier
{
    public StatType statConcernee;
    public float valeur; // Ex: 5 ou 0.1 (pour 10%)
}

[CreateAssetMenu(fileName = "Nouvel Item", menuName = "Système/Item")]
public class ItemData : ScriptableObject
{
    public string nomItem;
    [TextArea] public string description;

    // Liste des effets (Un item peut donner de la force ET de la vitesse)
    public List<StatModifier> bonusSats;
}