using UnityEngine;
using System;

public class ContainerCounter : BaseCounter
{
   [SerializeField] private KitchenObjectSO kitchenObjectSO;


   public event EventHandler OnPlayerGrabbedObject;
   public override void Interact(Player player)
   {
      // if there is no object on the counter then spawn the object on the counter
      if (!HasKitchenObject())
      {

         if (!player.HasKitchenObject())
         {
            // PLayer is not carrying anything 
            KitchenObject.SpawnKitchenobject(kitchenObjectSO, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
         }


      }

   }

}
