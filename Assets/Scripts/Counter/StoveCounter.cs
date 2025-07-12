using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecpieSO[] fryingRecpieSOArray;
    private float fryingProgress;
    void Update()
    {
        if (HasKitchenObject())
        {
            fryingProgress += Time.deltaTime;
            FryingRecpieSO fryingRecpieSO = GetFryingRecpieSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            if (fryingProgress > fryingRecpieSO.fryingTimerMax)
            {
                fryingProgress = 0;
                GetKitchenObject().Destoryself();

                KitchenObject.SpawnKitchenobject(fryingRecpieSO.output, this);

            }
        }
    }
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
                    // PLayer is Carrying Something that can fried
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
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO kitchenObjectSO)
    {
        FryingRecpieSO FryingRecpieSO = GetFryingRecpieSOWithInput(kitchenObjectSO);
        return FryingRecpieSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenobjectSO)
    {
        FryingRecpieSO fryingRecpieSO = GetFryingRecpieSOWithInput(inputKitchenobjectSO);
        return fryingRecpieSO.output != null ? fryingRecpieSO.output : null;
    }
    private FryingRecpieSO GetFryingRecpieSOWithInput(KitchenObjectSO inputKitchenObjectSO)
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
