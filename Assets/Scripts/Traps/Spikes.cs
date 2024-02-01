namespace Traps
{
    public class Spikes : Trap
    {
        protected override void PlayerCollided(Player.Player player)
        {
            damageAmount = player.MaximumHitpoints;
            player.Hit(this);
        }
    }
}