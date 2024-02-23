using System;
using UnityEngine;

namespace Platformer
{
    public abstract class Trap : DamageSource
    {
        protected enum TrapType
        {
            Damaging,
            Instakill
        }
        
        [SerializeField] protected TrapType trapType;

        protected override void PlayerCollidedHandler(Player player, DamageInfo damageInfo)
        {
            switch (trapType)
            {
                case TrapType.Instakill:
                    player.Killed();
                    break;
                case TrapType.Damaging:
                    player.Hit(damageInfo);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}