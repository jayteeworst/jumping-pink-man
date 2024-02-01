using System;
using UnityEngine;

namespace Traps
{
    public class Morgenstern : Trap
    {
        [SerializeField] private Transform rootTransform;
        [SerializeField] private float rotationSpeed = 1f;
        
        private void FixedUpdate()
        {
            rootTransform.Rotate(transform.forward, rotationSpeed);
        }

        protected override void PlayerCollided(Player.Player player)
        {
            player.Hit(this);
            rotationSpeed *= -1;
        }
    }
}
