using UnityEngine;

namespace Platformer
{
    public class Chest : RandomizedContainer
    {
        private Animator chestAnimator;
        private bool isOpen;
        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        protected override void Awake()
        {
            base.Awake();
            chestAnimator = GetComponent<Animator>();
        }

        public override void Interact(Player interactor)
        {
            if (!isInteractionEnabled) return;
            base.Interact(interactor);
            Open();
        }

        private void Open()
        {
            isOpen = true;
            chestAnimator.SetBool(IsOpened, isOpen);
            DisableInteraction();
            SpawnContents();
            AudioManager.Instance.ChestOpened(transform.position);
        }
    }
}