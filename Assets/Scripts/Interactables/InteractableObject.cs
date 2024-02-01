using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
   private BoxCollider2D interactionArea;
   protected bool isInteractionEnabled;
   [SerializeField] protected GameObject popup;

   protected virtual void Awake()
   {
      interactionArea = GetComponent<BoxCollider2D>();
      isInteractionEnabled = true;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player") || !isInteractionEnabled) return;
      
      popup.SetActive(true);
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;
      
      popup.SetActive(false);
   }

   public virtual void Interact(Player.Player interactor)
   {
      Debug.Log(interactor + " interacted with " + gameObject);
   }

   protected virtual void DisableInteraction()
   {
      popup.SetActive(false);
      isInteractionEnabled = false;
   }
}
