using UnityEngine;

public class ClearCounter : BaseCounter
{

   [SerializeField] private KitchenObjectSO kitchenObjectSO;

   public override void Interact(Player player)
   {
      if (!HasKitchenObject())
      {
         // There is no KitchenObject here
         if (player.HasKitchenObject())
         {
            // Player is carrying something 
            player.GetKitchenObject().SetkitchenObjectParent(this);
         }
         else
         {
            // player not carrying anything
         }
      }
      else
      {
         // There is a KitchenObject
         if (player.HasKitchenObject())
         {
            //player is carrying some things
         }
         else
         {
            // player is not carrying anything
            GetKitchenObject().SetkitchenObjectParent(player);
         }

      }

   }


}
