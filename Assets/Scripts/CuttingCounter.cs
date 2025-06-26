using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuttingCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is not kitcheobject here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                player.GetKitchenObject().SetkitchenObjectParent(this);
            }
            else
            {
                // pLayer not carrying anything
            }

        }
        else
        {
            // There is a kitchen Object here
            if (player.HasKitchenObject())
            {
                // PLayer is carrying something 
            }
            else
            {
                GetKitchenObject().SetkitchenObjectParent(player);
            }
        }
    }
}
