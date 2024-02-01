using UnityEngine;

namespace Traps
{
    public class Saw : Trap
    {
        protected override void PlayerCollided(Player.Player player)
        {
            player.Hit(this);
        }
    }
}