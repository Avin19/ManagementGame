using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private IkitchenObjectParent kitchenobjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectParent(IkitchenObjectParent kitchenobjectParent)
    {       // clearing the kitchen object from the counter to setup a new kitchen object
        if (this.kitchenobjectParent != null)
        {
            this.kitchenobjectParent.ClearKitchenObject();
        }

        this.kitchenobjectParent = kitchenobjectParent;
        if (this.kitchenobjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already a has a KitchenObject");
        }
        // setting the new object to clear counter
        this.kitchenobjectParent.SetKitchenObject(this);

        // transferring the kitchen object to the receiver countertop 
        transform.parent = this.kitchenobjectParent.GetKitchenobjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IkitchenObjectParent GetkitchenObjectParent()
    {
        return kitchenobjectParent;
    }

    public void Destoryself()
    {
        // Clear the kitchen object from the counter top 
        kitchenobjectParent.ClearKitchenObject();

        Destroy(gameObject);
    }


    public static KitchenObject SpawnKitchenobject(KitchenObjectSO kitchenObjectSO, IkitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.perfabs);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
