using UnityEngine;

namespace Platformer
{
    public static class PlayerAnimatorConstants
    {
        public static readonly int Death = Animator.StringToHash("Death");
        public static readonly int Hit = Animator.StringToHash("Hit");
        public static readonly int Restart = Animator.StringToHash("Restart");
        public static readonly int Running = Animator.StringToHash("Running");
        public static readonly int Jumping = Animator.StringToHash("Jumping");
        public static readonly int Falling = Animator.StringToHash("Falling");
        public static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        public static readonly int RunSpeed = Animator.StringToHash("RunSpeed");
    }
}