using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class PlayerInvincibilityToggle : MonoBehaviour
    {
        [SerializeField] private PlayerVisuals _playerVisuals;
        [SerializeField] private float _invincibilityTime = 3f;

        public void SetInvincibility()
        {
            StartCoroutine(MakeTemporarilyInvincible());
        }
        
        private IEnumerator MakeTemporarilyInvincible()
        {
            GameLayers.IgnoreCollisionWithTraps(true);
            _playerVisuals.ToggleTransparency(true);
            
            yield return new WaitForSeconds(_invincibilityTime);
            
            GameLayers.IgnoreCollisionWithTraps(false);
            _playerVisuals.ToggleTransparency(false);
        }
    }
}
