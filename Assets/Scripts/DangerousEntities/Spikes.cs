using UnityEngine;

namespace Platformer
{
    public class Spikes : Trap
    {
        protected override void PlayerCollidedHandler(Player player, DamageInfo damageInfo)
        {
            base.PlayerCollidedHandler(player, damageInfo);
            Debug.Log(player + "got SPIKED!");
        }
    }
}