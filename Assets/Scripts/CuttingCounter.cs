using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuttingCounter : BaseCounter
{

    [SerializeField]
    private CuttingRecpieSO[] cuttingRecpieSOArray;
    private int cuttingProgress;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is not kitcheobject here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    cuttingProgress = 0;
                    // player carrying something that can be cutting 
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlterante(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // There is a kitchen object ready to cut and it can be cut
            cuttingProgress++;
            CuttingRecpieSO cuttingRecpieSO = cuttingRecpieSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            if (cuttingProgress >= cuttingRecpieSO.cuttingProgressmax)
            {
                // Destory the kitchen object 
                // Spawn the new chopped object 
                KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().Destoryself();
                KitchenObject.SpawnKitchenobject(outputKitchenObjectSO, this);

            }


        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO kitchenObjectSO)
    {
        CuttingRecpieSO cuttingRecpieSO = cuttingRecpieSOWithInput(kitchenObjectSO);
        return cuttingRecpieSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenobjectSO)
    {
        CuttingRecpieSO cuttingRecpieSO = cuttingRecpieSOWithInput(inputKitchenobjectSO);
        return cuttingRecpieSO.output != null ? cuttingRecpieSO.output : null;
    }
    private CuttingRecpieSO cuttingRecpieSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecpieSO cuttingRecpieSO in cuttingRecpieSOArray)
        {
            if (cuttingRecpieSO.input == inputKitchenObjectSO)
            {
                return cuttingRecpieSO;
            }
        }
        return null;
    }
}
