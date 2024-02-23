using UnityEngine;

public static class GameLayers
{
    public static readonly int InteractableLayerMask = 1 << LayerMask.NameToLayer("Interactable");

    private static readonly int PlayerLayer = LayerMask.NameToLayer("Player");
    private static readonly int TrapsLayer = LayerMask.NameToLayer("Trap");
    
            
    public static void IgnoreCollisionWithTraps(bool value)
    {
        Physics2D.IgnoreLayerCollision(PlayerLayer, TrapsLayer, value);
    }
}
