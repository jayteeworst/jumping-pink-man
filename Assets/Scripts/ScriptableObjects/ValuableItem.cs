using UnityEngine;

[CreateAssetMenu(fileName = "ValuableItem", menuName = "Items/ValuableItem")]
public class ValuableItem : ScriptableObject
{
    public string itemName;
    public int itemValue;
    public float dropChance;
    public GameObject prefabSource;
}
