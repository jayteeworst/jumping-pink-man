using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTable", menuName = "Items/DropTable")]
public class DropTable : ScriptableObject
{
    public List<ValuableItem> possibleDrops = new();

    public float TotalWeight()
    {
        var sum = 0f;
        foreach (var valuableItem in possibleDrops)
        {
            sum += valuableItem.dropChance;
        }

        return sum;
    }
}
