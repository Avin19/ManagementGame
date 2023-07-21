using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private IkitchenObjectParent kitchenobjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetkitchenObjectParent(IkitchenObjectParent kitchenobjectParent)
    {       // clearing the kitchen object from the counter to setup a new kitchen object
            if(this.kitchenobjectParent != null)
            {
                this.kitchenobjectParent.ClearKitchenObject();
            }

            this.kitchenobjectParent = kitchenobjectParent;
            if(this.kitchenobjectParent.HasKitchenObject())
            {
            Debug.LogError("Counter already a has a KitchenObject");
            }
            // setting the new object to clear counter
            this.kitchenobjectParent.SetKitchenObject(this);

            // transferring the kitchen objec to the receiver countertop 
            transform.parent = this.kitchenobjectParent.GetKitchenobjectFollowTransform();
            transform.localPosition = Vector3.zero;
    }
    public IkitchenObjectParent GetkitchenObjectParent()
    {
        return kitchenobjectParent;
    }
}
