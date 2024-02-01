using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/ConsumableItem")]
public class ConsumableItem : ScriptableObject
{
    public string itemName;
    public int healthRestored;
}
