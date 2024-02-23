using UnityEngine;

namespace Platformer
{
    public class Morgenstern : Trap
    {
        [SerializeField] private Transform rootTransform;
        [SerializeField] private float rotationSpeed = 1f;
        
        private void FixedUpdate()
        {
            rootTransform.Rotate(transform.forward, rotationSpeed);
        }

        protected override void PlayerCollidedHandler(Player player, DamageInfo damageInfo)
        {
            damageInfo.knockbackForce *= Mathf.Abs(rotationSpeed);
            base.PlayerCollidedHandler(player, damageInfo);
            rotationSpeed *= -1;
        }
    }
}
