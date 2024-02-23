using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Saw : Trap
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Patrol _patrol;
        [SerializeField] private float _onHitPauseDuration = 2f;
        
        protected override void PlayerCollidedHandler(Player player, DamageInfo damageInfo)
        {
            base.PlayerCollidedHandler(player, damageInfo);
            if(_onHitPauseDuration > 0) StartCoroutine(Pause());
        }

        private IEnumerator Pause()
        {
            _animator.speed = 0;
            _patrol.IsPaused = true;

            yield return new WaitForSeconds(_onHitPauseDuration);

            _animator.speed = 1;
            _patrol.IsPaused = false;

            yield return null;
        }
    }
}