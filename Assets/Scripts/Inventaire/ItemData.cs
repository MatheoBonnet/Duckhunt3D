using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StatModifier
{
    public StatType statConcernee;
    public float valeur;
}

[CreateAssetMenu(fileName = "Nouvel Item", menuName = "Système/Item")]
public class ItemData : ScriptableObject
{
    public string nomItem;
    [TextArea] public string description;

    public List<StatModifier> bonusSats;
}