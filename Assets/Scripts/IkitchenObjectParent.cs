using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IkitchenObjectParent
{
    public Transform GetKitchenobjectFollowTransform();
   
   // setting up the kitchen object to this counter
   public void SetKitchenObject(KitchenObject kitchenObject);
   
   // getting to know if kitchen object is aalready there
   public KitchenObject GetKitchenObject();
   
   //after sending kitchen object setting up to null 
   public void ClearKitchenObject();
  
   public bool HasKitchenObject();
   
}