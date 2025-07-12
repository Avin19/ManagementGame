using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecpieSO[] fryingRecpieSOArray;
    private float fryingProgress;
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
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingProgress = 0;
                    // player carrying something that can be cutting 
                    FryingRecpieSO fryingRecpieSO = cuttingRecpieSOWithInput(GetKitchenObject().GetKitchenObjectSO());


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
            fryingProgress++;
            // OnCut?.Invoke(this, EventArgs.Empty);
            FryingRecpieSO fryingRecpieSO = cuttingRecpieSOWithInput(GetKitchenObject().GetKitchenObjectSO());


            if (fryingProgress >= fryingRecpieSO.fryingTimerMax)
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
        FryingRecpieSO FryingRecpieSO = cuttingRecpieSOWithInput(kitchenObjectSO);
        return FryingRecpieSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenobjectSO)
    {
        FryingRecpieSO fryingRecpieSO = cuttingRecpieSOWithInput(inputKitchenobjectSO);
        return fryingRecpieSO.output != null ? fryingRecpieSO.output : null;
    }
    private FryingRecpieSO cuttingRecpieSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecpieSO fryingRecpieSO in fryingRecpieSOArray)
        {
            if (fryingRecpieSO.input == inputKitchenObjectSO)
            {
                return fryingRecpieSO;
            }
        }
        return null;
    }
}
